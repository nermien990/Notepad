using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notebad
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }
        private string txtcopy = "";
        private void NewEventHandler(object sender, EventArgs e)
        {
            if(rtb.Text != null)
            {
               DialogResult dialogResult = MessageBox.Show("Do You want to Save This Changes ?!", "Notebad", MessageBoxButtons.OKCancel);
               if(dialogResult == DialogResult.OK)
                {
                    SaveEventHandler(sender, e);
                }
                else
                {
                    rtb.Clear();
                }
            }
            else
            {
                rtb.Clear();
            }
        }

        private void SaveEventHandler(object sender, EventArgs e)
        {
            dlgsave.Filter = "Plain Text Files|*.txt|Rich Text Files|*.rtf";
            if(dlgsave.ShowDialog() == DialogResult.OK)
            {
                rtb.SaveFile(dlgsave.FileName);
            }
         }

        private void OpenEventHandler(object sender, EventArgs e)
        {
            dlgopen.Filter = "Plain Text Files|*.txt|Rich Text Files|*.rtf";
            if(dlgopen.ShowDialog() == DialogResult.OK)
            {
                rtb.LoadFile(dlgopen.FileName);
            }
        }

        private void FontdlgHandler(object sender, EventArgs e)
        {
            dlgfont.Font = rtb.SelectionFont;
            if(dlgfont.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionFont = dlgfont.Font;
            }
        }

        private void ColordlgHandler(object sender, EventArgs e)
        {
            dlgcolor.Color = rtb.SelectionColor;
            if(dlgcolor.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionColor = dlgcolor.Color;
            }
        }
        private void CopyEventHandler(object sender, EventArgs e)
        {
            txtcopy = rtb.SelectedText;
        }
        private void CutEventHandler(object sender, EventArgs e)
        {
            txtcopy = rtb.SelectedText;
            rtb.SelectedText = "";
        }
        private void PasteEventHandle(object sender, EventArgs e)
        {
            rtb.SelectedText = txtcopy;
        }
        private void DeleteEventHandler(object sender, EventArgs e)
        {
            rtb.SelectedText = "";
        }
        private void SellectAllEventHandler(object sender, EventArgs e)
        {
            rtb.SelectAll();
        }

        private void NoOfWords(object sender, EventArgs e)
        {
            nowords.Text = rtb.Text.Count().ToString();
        }


        private void ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

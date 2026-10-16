using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        bool deyisiklikVar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            deyisiklikVar = true;
            toolStripStatusLabel1.Text = "Simvol sayı" + richTextBox1.Text.Length.ToString();
        }

        private void şiriftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void rəngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                deyisiklikVar = false; 
            }
        }

        private void saxlamaqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                deyisiklikVar = false; 
            }
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deyisiklikVar == true) 
            {
                DialogResult cavab = MessageBox.Show("Saxlamaq istəyirsiniz?", "Xeberdarliq", MessageBoxButtons.YesNoCancel);
                if (cavab == DialogResult.Yes) 
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                }
                else if (cavab == DialogResult.Cancel) 
                {
                    return;
                }
            }
            
            richTextBox1.Text = "";
            deyisiklikVar = false;
        }

        private void çıxışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deyisiklikVar == true)
            {
                DialogResult cavab = MessageBox.Show("Fayl yadda saxlanmayıb", "Xəbərdarlıq", MessageBoxButtons.YesNoCancel);

                if (cavab == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                }
                else if (cavab == DialogResult.Cancel)
                {
                    return; 
                }
            }
           
            Application.Exit();
        }
    }
}

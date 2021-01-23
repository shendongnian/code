    using System;
    using System.Linq; //note we import the Linq namespace to we can use .ToList()
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.IO;
    
    namespace Keywords
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            OpenFileDialog ofd = new OpenFileDialog();
    
            public void button1_Click(object sender, EventArgs e)
            {
                ofd.Filter = "TXT|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = ofd.FileName;
                    string filePath = ofd.FileName;
                    string path = ofd.FileName;
                    List<string> fileItems = File.ReadAllLines(path).ToList();                   
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
             public static string[] topicContents = new string[] { "MECHANICS", "THEORY_OF_RELATIVITY" };
            public static string[] VarItemsMechanics = new string[] { "Test", "Wavelength" };
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                listBox1.DataSource = topicContents;
    
            }
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                string curItem = listBox1.SelectedItem.ToString();
                switch (curItem)
                {
                    case "MECHANICS":
                       listBox2.DataSource = VarItemsMechanics;
                        break;
                }
    
            }
        }
    }

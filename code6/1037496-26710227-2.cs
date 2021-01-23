    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private string p;
    
            public Form1()
            {
                InitializeComponent();
    
                
    
            }
    
            public Form1(string filePath):this()
            {
                MessageBox.Show("Loading file "+ filePath);
                CheckForAllowed(filePath);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                openFileDialog1.Multiselect = false;
                DialogResult dr=  openFileDialog1.ShowDialog();
                
                if (dr == System.Windows.Forms.DialogResult.OK)
                    CheckForAllowed(openFileDialog1.FileName);
    
            }
    
            private void CheckForAllowed(string filePath)
            {
                string appSetting = ConfigurationManager.AppSettings["ExtensionSupported"];
                MessageBox.Show("Allowed file types are " + appSetting);
                string[] allowedFileTypes = appSetting.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
                string fileExtesnsion = filePath.Substring(filePath.LastIndexOf('.')+1).Trim();
    
    
    
                if (allowedFileTypes.Contains(fileExtesnsion))
                    label1.Text = "Allowed";
                else
                    label1.Text = "Not allowed";
            }
    
        }
    }

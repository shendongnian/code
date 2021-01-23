    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32;
    
    namespace IDMListSaver
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\DownloadManager");
                string[] keys = key.GetSubKeyNames();
                for (int i = 0; i <= key.SubKeyCount-1; i++)
                {
                    key = key.OpenSubKey(keys[i]);
                    Object o = key.GetValue("Url0");
                    if (o != null)
                    {
                        listBox1.Items.Add(o);
                    }
                    key = Registry.CurrentUser.OpenSubKey("Software\\DownloadManager");
                }
            }
        }
    }

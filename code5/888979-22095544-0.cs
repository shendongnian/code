    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace TrayIconExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private NotifyIcon icon;
            private void button1_Click(object sender, EventArgs e)
            {
                icon = new NotifyIcon
                {
                    Icon = new Icon(@"C:\Program Files (x86)\Winspector\class-icons\#32768.ico"),
                    Visible = true
                };
                Hide();
            }
        }
    }

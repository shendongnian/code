    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TFF
    {
        public partial class Form1 : Form
        {
            private static DateTime? button1ClickAt = null;
            private static DateTime? button2ClickAt = null;
    
            public Form1()
            {
                InitializeComponent();
                HandleButtonEnable();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                button1ClickAt = DateTime.Now;
                HandleButtonEnable();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                button2ClickAt = DateTime.Now;
                HandleButtonEnable();
            }
    
            private void HandleButtonEnable()
            {
                button1.Enabled = (button1ClickAt == null || button1ClickAt.Value.Date != DateTime.Now.Date);
                button2.Enabled = (button2ClickAt == null || button2ClickAt.Value.Date != DateTime.Now.Date);
            }
        }
    }

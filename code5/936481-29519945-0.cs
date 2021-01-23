    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MSTSCLib;
    
    namespace RemoteTool
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MSTerminalServiceControl1.Server = textBox1.Text;
                MSTerminalServiceControl1.UserName = textBox2.Text;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)MSTerminalServiceControl1.GetOcx();
                secured.ClearTextPassword = textBox3.Text;
                MSTerminalServiceControl1.Connect();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MSTerminalServiceControl1.Disconnect();
            }
        }
    }

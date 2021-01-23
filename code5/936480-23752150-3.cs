    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using RDPCOMAPILib;
    using AxRDPCOMAPILib;
    namespace Simple_RDP_Client
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public static void Connect(string invitation, AxRDPViewer display, string userName, string password)
            {
                display.Connect(invitation, userName, password);
            }
            public static void disconnect(AxRDPViewer display)
           {
                display.Disconnect();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                 try
                {
                     Connect(textConnectionString.Text, this.axRDPViewer, "", "");
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to connect to the Server");
                }
            }
        }
    }

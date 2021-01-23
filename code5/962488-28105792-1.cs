    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace RemoteAssist
    {
        public partial class FrmConnect : Form
        {
            public FrmConnect()
            {
                InitializeComponent();
            }
    
         private void btnConnect_Click(object sender, EventArgs e)
            {
                RemoteConnect remoteConnect = new RemoteConnect();
                Boolean status = remoteConnect.StartRemoteAssistance(txtComputerName.Text.ToString(), true,false);
                if (status == false)
                {
    System.Windows.Forms.MessageBox.Show("Unable to Connect to the Remote Machine.Please try Again later.");
                }
            }
    
            private void BtnInvite_Click(object sender, EventArgs e)
            {
                RemoteConnect remoteConnect = new RemoteConnect();
                Boolean status;
                status = remoteConnect.StartRemoteAssistance(txtComputerName.Text.ToString(), false, true);
                
                if (status == false)
                {
                    System.Windows.Forms.MessageBox.Show("Unable to Establish Connection, Please try Again later.");
                }
            }
    
            private void FrmConnect_Load(object sender, EventArgs e)
            {
            }
    
            private void txtComputerName_TextChanged(object sender, EventArgs e)
            {
                txtComputerName.CharacterCasing = CharacterCasing.Upper;
            }             
        }
    }
    

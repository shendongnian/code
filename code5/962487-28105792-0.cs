    Remote Assistance using the MSRA Exe and its arguments.
    
    Here I have desinged a class and a form,  and it gives you the following functionalities,
    
    1)	Offer Remote Assistance to a Machine
    2)	Ask for Remote Help. (Invite someone to help you)
    
    Design A form with the folloiwng controls,
    
    1)	Textbox for taking the IP or Computer name to Connect
    2)	Button 1. To connect to the Remote Machine for offering Remote Assistance
    3)	Button 2. To Ask or invite someone to help.
    
    
     
    
    Code Behind in the Form:
    
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
                Boolean status;
    status = remoteConnect.StartRemoteAssistance(txtComputerName.Text.ToString(), true,false);
    
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
    
    We have two buttons here and they are sending the Boolean variable to the class function for differentiating between offer Help and Asking for Help.
    
     
    Code under the Class File : RemoteConnect
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RemoteAssist
    {
        class RemoteConnect
        {
            public Boolean StartRemoteAssistance(String strMachinename, Boolean offerHelp, Boolean askForHelp)
            {            
                System.Diagnostics.Process process = new System.Diagnostics.Process();                        
    
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;            
                startInfo.FileName = "msra.exe";
    
                // Offer Remote Assitance 
                if (offerHelp == true)
                {
                    startInfo.Arguments = "/offerRA " + strMachinename;
                }
    
                //ASK for Remote Assistance
                if (askForHelp == true)
                {
                    startInfo.Arguments = "novice";
                }
    
                try
                {
                    process.StartInfo = startInfo;
                    process.Start();
                    return true;
                }
    
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show("Error Occured while trying to Connect" + ex.Message);
                    return false;
                }           
            }
        }
    }

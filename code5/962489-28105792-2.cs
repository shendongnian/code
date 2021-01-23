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

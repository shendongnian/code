    public void getWMIdata(string query)
        {
            ConnectionOptions co = new ConnectionOptions();
            co.EnablePrivileges = true;
            co.Impersonation = ImpersonationLevel.Impersonate;
            co.Username = TextBox2_userID.Text;
            co.Password = TextBox3_password.Text;
    
            string host = TextBox1_serverName.Text;
    
            string wmiNameSpace = @"root\cimv2";
            ManagementScope scope = new ManagementScope(string.Format(@"\\{0}\{1}", host, wmiNameSpace), co);
    
            try
            { 
    
                ObjectQuery objquery = new ObjectQuery(query);       
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, objquery);
                ManagementObjectCollection queryCollection = searcher.Get();
                string displayedText = ""; // Here
    
                foreach (ManagementObject queryObj in queryCollection)
                {
    
                    ////convert free disk space size from bytes to GB's
                    double fdsbytes = Convert.ToDouble(queryObj["FreeSpace"].ToString());
                    double fdsGB = Math.Round((fdsbytes / Math.Pow(1024, 3)), 2);
                    string fdsFinal = @"Free Disk Space: " + Convert.ToString(fdsGB) + @"GB";
    
                    ////convert total disk drive size from bytes to GB's
                    double dsbytes = Convert.ToDouble(queryObj["Size"].ToString());
                    double dsGB = Math.Round((dsbytes / Math.Pow(1024, 3)), 2);
                    string dsFinal = @"Disk Drive Size: " + Convert.ToString(dsGB) + @"GB";
    
                    ////% free disk space
                    double a = Math.Round((100 * (fdsGB / dsGB)), 2);
                    string percentfreespace = @"% Free Space: " + Convert.ToString(a) + @"GB";
    
                    string name = @"Drive Name: " + queryObj["Name"].ToString();
    
                    string description = @"Drive Description: " + queryObj["Description"].ToString();
                    // add this to the text variable to be displayed
    
                    displayedText += fdsFinal + Environment.NewLine + dsFinal + Environment.NewLine + percentfreespace + Environment.NewLine + name + Environment.NewLine + description + Environment.NewLine + Environment.NewLine;
    
                } 
                  
                // set text to be displayed
                TextBox1_wmiOutput.Text = displayedText;
    
            }
            catch (ManagementException ex)
            {
                Label3_wmiErrorMesage.Text = @"Error Message: " + ex.Message.ToString();
    
            } 
    
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 const string userRoot = "HKEY_CURRENT_USER";
                 const string subkey = @"Software\Microsoft\OneDrive";
                 const string keyName = userRoot + "\\" + subkey;
                 string oneDrivePath = (string)Microsoft.Win32.Registry.GetValue(keyName,
                    "UserFolder",
                   "Return this default if NoSuchName does not exist.");
                 Console.WriteLine("\r\n OneDrivePath : {0}", oneDrivePath);
                string Onedrivepath= string.Format(oneDrivePath);
                 label1 .Text = string.Format(Onedrivepath);
            }
            catch (Exception)
            {
                /// throw;
            }
        }
   

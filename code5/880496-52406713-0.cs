    //.. your code
    // Calling function inside Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            Get45PlusFromRegistry();
        }
    //Functions
            private static void Get45PlusFromRegistry()
            {
                const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
    
                using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
                {
                    if (ndpKey != null && ndpKey.GetValue("Release") != null)
                    {
                        //Do nothing if .Net 4.5 or higher is found.
                        //MessageBox.Show(".NET Framework Version: " + CheckFor45PlusVersion((int)ndpKey.GetValue("Release")));
                    }
                    else
                    {
                        // Do something if .Net 4.5 or higher is found
                        MessageBox.Show("This program Requires .NET Framework Version 4.5 or later. Click OK to access Microsoft official website and download .NET 4.5 framework.");
                        Process.Start(@"https://www.microsoft.com/en-us/download/details.aspx?id=30653");
                    }
                }
            }
    
            // Checking the version using >= will enable forward compatibility.
            private static string CheckFor45PlusVersion(int releaseKey)
            {
                if (releaseKey >= 461808)
                    return "4.7.2 or later";
                if (releaseKey >= 461308)
                    return "4.7.1";
                if (releaseKey >= 460798)
                    return "4.7";
                if (releaseKey >= 394802)
                    return "4.6.2";
                if (releaseKey >= 394254)
                    return "4.6.1";
                if (releaseKey >= 393295)
                    return "4.6";
                if (releaseKey >= 379893)
                    return "4.5.2";
                if (releaseKey >= 378675)
                    return "4.5.1";
                if (releaseKey >= 378389)
                    return "4.5";
                // This code should never execute. A non-null release key should mean
                // that 4.5 or later is installed.
                return "No 4.5 or later version detected";
            }
    //..your code

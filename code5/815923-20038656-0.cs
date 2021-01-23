    static void Main(string[] args)
            {
                /*
                Your Code here
                */
       
                
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
    
            }
            static private void CurrentDomain_ProcessExit(object sender, EventArgs e)
            {
                RegistryKey inetproxyRegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
                inetproxyRegKey.SetValue("ProxyEnable",1);
    
            }

    ...
    using Microsoft.Win32;
    using System.Net;
    ...
    string hostName = 192.168.1.1;
    
    using (new NetworkConnection(@"\\" + hostName + @"\admin$", new NetworkCredential(@"ad\administrator", "TopSecret")))
    {
        using (RegistryKey remoteHklm = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, hostName))
        {
            using (RegistryKey serviceKey = remoteHklm.OpenSubKey("System\\CurrentControlSet\\Services", true))
            {
                if (serviceKey != null)
                {
                    foreach (string key in serviceKey.GetSubKeyNames())
                    {
                        Console.WriteLine(key);
                    }
                }
            }
        }
    }
    

        public void GetNameAndVersion()
        {
            Microsoft.Win32.RegistryKey iRegKey = null;
            Microsoft.Win32.RegistryKey iSubKey = null;
            string eValue = null;
            string eVersion = null;
            string regpath = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
            iRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regpath);
            string[] subkeys = iRegKey.GetSubKeyNames();
            bool includes = false;
            foreach (string subk in subkeys)
            {
                iSubKey = iRegKey.OpenSubKey(subk);
                 eValue = Convert.ToString(iSubKey.GetValue("DisplayName", ""));
                 eVersion = Convert.ToString(iSubKey.GetValue("DisplayVersion", ""));
                 if (eValue != null && eValue.Contains("Firefox"))
                 {
                    var version = eVersion;
                     var parsedversion = Version.Parse(version);
                     var minimumversion = new Version("35.0.1");
                     if (parsedversion >= minimumversion)
                         listView1.Items.Add(new ListViewItem { ImageIndex = 0, Text = "Firefox is the latest version or newer" });
                     else if (parsedversion < minimumversion)
                         listView1.Items.Add(new ListViewItem { ImageIndex = 0, Text = "Firefox needs reinstalled" });
                 
                 else
                     includes = false;
                 }
            }
        }
    }
}

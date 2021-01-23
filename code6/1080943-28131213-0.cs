    private void SetProxy(string Proxy)
        {
            string key = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(key, true);
            RegKey.SetValue("ProxyServer", Proxy);
            if (Proxy == "")
            {
                RegKey.SetValue("ProxyEnable", 0);
            }
            else
            {
                RegKey.SetValue("ProxyEnable", 1);
            }
        }

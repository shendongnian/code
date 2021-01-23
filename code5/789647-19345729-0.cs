        Process p = new Process();
        string browser = string.Empty;
        RegistryKey key = null;
        try
        {
            key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
            //trim off quotes
            browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
            if (!browser.EndsWith("exe"))
            {
                //get rid of everything after the ".exe"
                browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
            }
        }
        finally
        {
            if (key != null) key.Close();
        }
        p.StartInfo.FileName = browser;
        p.StartInfo.Arguments = "http://www.google.com";
        p.Start();

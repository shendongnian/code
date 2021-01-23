    string dataURI = "data:text/html,<html><p>This is a test</p></html>";
    string browser = GetBrowserPath();
    if(string.IsNullOrEmpty(browser))
        browser = "iexplore.exe";
    System.Diagnostics.Process p = new Process();
    p.StartInfo.FileName = browser;
    p.StartInfo.Arguments = dataURI;
    p.Start();
    private string GetBrowserPath()
    {
        string browser = string.Empty;
        Microsoft.Win32.RegistryKey key = null;
        try
        {
            // try location of default browser path in XP
            key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
            // try location of default browser path in Vista
            if (key == null)
            {
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
            }
            if (key != null)
            {
                //trim off quotes
                browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
                if (!browser.EndsWith("exe"))
                {
                    //get rid of everything after the ".exe"
                    browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
                }                    
            }
        }
        finally
        {
            if (key != null) key.Close();
        }
        return browser;
    }

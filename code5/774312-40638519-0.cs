    public static string GetActiveTabUrl()
    {
      Process[] procsChrome = Process.GetProcessesByName("chrome");
      if (procsChrome.Length <= 0)
        return null;
      foreach (Process proc in procsChrome)
      {
        // the chrome process must have a window 
        if (proc.MainWindowHandle == IntPtr.Zero)
          continue;
        // to find the tabs we first need to locate something reliable - the 'New Tab' button 
        AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
        var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
        if (SearchBar != null)
          return (string)SearchBar.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty);
      }
      return null;
    }

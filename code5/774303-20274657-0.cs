    public IEnumerable<string> GetTabs()
    {
      // there are always multiple chrome processes, so we have to loop through all of them to find the
      // process with a Window Handle and an automation element of name "Address and search bar"
      var processes = Process.GetProcessesByName("chrome");
      var automationElements = from chrome in processes
                               where chrome.MainWindowHandle != IntPtr.Zero
                               select AutomationElement.FromHandle(chrome.MainWindowHandle);
      return from element in automationElements
             select element.GetUrlBar()
             into elmUrlBar
             where elmUrlBar != null
             where !((bool) elmUrlBar.GetCurrentPropertyValue(AutomationElement.HasKeyboardFocusProperty))
             let patterns = elmUrlBar.GetSupportedPatterns()
             where patterns.Length == 1
             select elmUrlBar.TryGetValue(patterns)
             into ret
             where ret != ""
             where Regex.IsMatch(ret, @"^(https:\/\/)?[a-zA-Z0-9\-\.]+(\.[a-zA-Z]{2,4}).*$")
             select ret.StartsWith("http") ? ret : "http://" + ret;
    }

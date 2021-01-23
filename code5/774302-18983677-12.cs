    // there are always multiple chrome processes, so we have to loop through all of them to find the
    // process with a Window Handle and an automation element of name "Address and search bar"
    Process[] procsChrome = Process.GetProcessesByName("chrome");
    foreach (Process chrome in procsChrome) {
      // the chrome process must have a window
      if (chrome.MainWindowHandle == IntPtr.Zero) {
        continue;
      }
      // find the automation element
      AutomationElement elm = AutomationElement.FromHandle(chrome.MainWindowHandle);
      // manually walk through the tree, searching using TreeScope.Descendants is too slow (even if it's more reliable)
      AutomationElement elmUrlBar = null;
      try {
        // walking path found using inspect.exe (Windows SDK) for Chrome 31.0.1650.63 m (currently the latest stable)
        var elm1 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
        if (elm1 == null) { continue; } // not the right chrome.exe
        // here, you can optionally check if Incognito is enabled:
        //bool bIncognito = TreeWalker.RawViewWalker.GetFirstChild(TreeWalker.RawViewWalker.GetFirstChild(elm1)) != null;
        var elm2 = TreeWalker.RawViewWalker.GetLastChild(elm1); // I don't know a Condition for this for finding :(
        var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
        var elm4 = elm3.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar));
        elmUrlBar = elm4.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
      } catch {
        // Chrome has probably changed something, and above walking needs to be modified. :(
        // put an assertion here or something to make sure you don't miss it
        continue;
      }
      // make sure it's valid
      if (elmUrlBar == null) {
        // it's not..
        continue;
      }
      // elmUrlBar is now the URL bar element. we have to make sure that it's out of keyboard focus if we want to get a valid URL
      if ((bool)elmUrlBar.GetCurrentPropertyValue(AutomationElement.HasKeyboardFocusProperty)) {
        continue;
      }
      // there might not be a valid pattern to use, so we have to make sure we have one
      AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
      if (patterns.Length == 1) {
        string ret = "";
        try {
          ret = ((ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0])).Current.Value;
        } catch { }
        if (ret != "") {
          // must match a domain name (and possibly "https://" in front)
          if (Regex.IsMatch(ret, @"^(https:\/\/)?[a-zA-Z0-9\-\.]+(\.[a-zA-Z]{2,4}).*$")) {
            // prepend http:// to the url, because Chrome hides it if it's not SSL
            if (!ret.StartsWith("http")) {
              ret = "http://" + ret;
            }
            Console.WriteLine("Open Chrome URL found: '" + ret + "'");
          }
        }
        continue;
      }
    }

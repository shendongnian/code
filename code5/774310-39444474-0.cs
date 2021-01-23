    Process[] procsChrome = Process.GetProcessesByName("chrome");
    foreach (Process chrome in procsChrome)
    {
        if (chrome.MainWindowHandle == IntPtr.Zero)
            continue;
        AutomationElement element = AutomationElement.FromHandle(chrome.MainWindowHandle);
        if (element == null)
            return null;
        Condition conditions = new AndCondition(
            new PropertyCondition(AutomationElement.ProcessIdProperty, chrome.Id),
            new PropertyCondition(AutomationElement.IsControlElementProperty, true),
            new PropertyCondition(AutomationElement.IsContentElementProperty, true),
            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                 
        AutomationElement elementx = element.FindFirst(TreeScope.Descendants, conditions);
        return ((ValuePattern)elementx.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
    }

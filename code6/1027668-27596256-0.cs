    public static string GetChromeUrl(Process process)
    {
      if (process == null)
        throw new ArgumentNullException("process");
      if (process.MainWindowHandle == IntPtr.Zero)
        return null;
      AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
      if (element == null)
        return null;
      AutomationElement edit = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
      if (edit == null)
      {
        AutomationElementCollection edits5 = element.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
        edit = edits5[0];
      }
      return ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
    }

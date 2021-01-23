    public static class AutomationElementExtensions
    {
      public static AutomationElement GetUrlBar(this AutomationElement element)
      {
        try
        {
          return InternalGetUrlBar(element);
        }
        catch
        {
          // Chrome has probably changed something, and above walking needs to be modified. :(
          // put an assertion here or something to make sure you don't miss it
          return null;
        }
      }
      public static string TryGetValue(this AutomationElement urlBar, AutomationPattern[] patterns)
      {
        try
        {
          return ((ValuePattern) urlBar.GetCurrentPattern(patterns[0])).Current.Value;
        }
        catch
        {
          return "";
        }
      }
      //
      private static AutomationElement InternalGetUrlBar(AutomationElement element)
      {
        // walking path found using inspect.exe (Windows SDK) for Chrome 29.0.1547.76 m (currently the latest stable)
        var elm1 = element.FindFirst(TreeScope.Children,
          new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
        var elm2 = TreeWalker.RawViewWalker.GetLastChild(elm1); // I don't know a Condition for this for finding :(
        var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
        var elm4 = elm3.FindFirst(TreeScope.Children,
          new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar));
        var result = elm4.FindFirst(TreeScope.Children,
          new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
        return result;
      }
    }

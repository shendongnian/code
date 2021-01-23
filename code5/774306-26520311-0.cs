    var elm1 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
    if (elm1 == null) { continue; }  // not the right chrome.exe
    var elm2 = TreeWalker.RawViewWalker.GetLastChild(elm1);
    var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.HelpTextProperty, "TopContainerView"));
    var elm4 = elm3.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar));
    var elm5 = elm4.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.HelpTextProperty, "LocationBarView"));
    elmUrlBar = elm5.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

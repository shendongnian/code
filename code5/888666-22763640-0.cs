    List<AutomationElement> messages = new List<AutomationElement>();
    AutomationElement parentDatagrid;//your AE
    
    Condition yourCond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem));
    AutomationElementCollection aECollection;
    aECollection= parentDatagrid.FindAll(TreeScope.Element | TreeScope.Descendants, yourCond);
    foreach (AutomationElement element in aECollection)
    {
        //whatever you like
    }

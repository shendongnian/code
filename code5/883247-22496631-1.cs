    private void WalkControlElements(AutomationElement rootElement, ...)
    {
        AutomationElementCollection childElements = rootElement.FindAll(TreeScope.Children, Automation.ControlViewCondition);
    
        foreach (AutomationElement elementNode in childElements)
        {
            if( rootElement == TreeWalker.ControlViewWalker.GetParent(elementNode) )
                WalkControlElements(elementNode, ... );
        }
    }

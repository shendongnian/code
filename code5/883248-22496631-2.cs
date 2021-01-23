    private void WalkControlElements(AutomationElement rootElement, ...){
         WalkControlElements(elementNode, false, ... );
    }
    private void WalkControlElements(AutomationElement rootElement, bool treeValidationExceptionShouldFail, ...)
    {
        AutomationElementCollection childElements = rootElement.FindAll(TreeScope.Children, Automation.ControlViewCondition);
    
        foreach (AutomationElement elementNode in childElements)
        {
            if( rootElement == TreeWalker.ControlViewWalker.GetParent(elementNode) )
                WalkControlElements(elementNode, treeValidationExceptionShouldFail, ... );
            else
                WalkControlElements(elementNode, true, ... );
        }
    }

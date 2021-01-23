    public AutomationElement findControl(AutomationProperty propertyOfItem, string itemToSearchFor, System.Windows.Automation.ControlType controlType)
    {
                Condition condition = new System.Windows.Automation.AndCondition(
                       new System.Windows.Automation.PropertyCondition(propertyOfItem, itemToSearchFor),
                       new System.Windows.Automation.PropertyCondition(AutomationElement.ControlTypeProperty, controlType));
        
                AutomationElement foundControl = AutomationElement.RootElement.FindFirst(TreeScope.Descendants | TreeScope.Children, condition);
                return foundControl;
    }

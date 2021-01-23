    using System.Windows.Automation;
    ....
    static AutomationElement FindById(AutomationElement root, string id, bool directChild)
    {
        Assert(root != null, "Invalid input: ParentWindow element 'root' is null.");
        Condition conditions = new PropertyCondition(AutomationElement.AutomationIdProperty, id);
        return root.FindFirst(directChild ? TreeScope.Children : TreeScope.Descendants, conditions);
    }
    ....
    AutomationElement button = FindById(containerWindow, id.ToString(), true);
    InvokePattern invokePattern = null;
    try
    {
        invokePattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
    }
    catch (InvalidOperationException)
    {
        MessageBox.Show("The UI element named " + button.GetCurrentPropertyValue(AutomationElement.NameProperty) + " is not a button");
        return false;
    }
    invokePattern.Invoke();

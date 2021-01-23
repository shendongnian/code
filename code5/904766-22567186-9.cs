    System.Windows.Interactivity.EventTrigger trigger = 
        new System.Windows.Interactivity.EventTrigger();
    trigger.EventName = "KeyDown";
    System.Windows.Interactivity.InvokeCommandAction keyDownAction =
        new System.Windows.Interactivity.InvokeCommandAction();
    keyDownAction.Command = KeyDownCommand;
    trigger.Actions.Add(keyDownAction);
    trigger.Attach(yourTabItem);

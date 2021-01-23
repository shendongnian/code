    FrameworkElement ctrl = control; //or whatever you're passing in, since all controls are FrameworkElements.
    // Move to a parent that can take focus
    FrameworkElement parent = (FrameworkElement)ctrl.Parent;
    while (parent != null && parent is IInputElement 
                      && !((IInputElement)parent).Focusable)
    {
        parent = (FrameworkElement)parent.Parent;
    }
    DependencyObject scope = FocusManager.GetFocusScope(ctrl); //can pass in ctrl here because FrameworkElement inherits from DependencyObject
    FocusManager.SetFocusedElement(scope, parent as IInputElement);

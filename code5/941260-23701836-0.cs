    static void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        IInputElement focusedElement = e.NewFocus;
        for (DependencyObject d = focusedElement as DependencyObject; 
    		d != null; d = VisualTreeHelper.GetParent(d)) {
            if (FocusManager.GetIsFocusScope(d)) {
                d.SetValue(FocusManager.FocusedElementProperty, focusedElement);
                if (!(bool)d.GetValue(IsEnhancedFocusScopeProperty)) {
                    break;
                }
            }
        }
    }

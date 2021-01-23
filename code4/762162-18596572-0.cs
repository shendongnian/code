    protected virtual void RegisterForKeyboardNotifications()
    {
        NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
        NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
    }
    private void OnKeyboardNotification (NSNotification notification)
    {
        var keyboardVisible = notification.Name == UIKeyboard.WillShowNotification;
        if (keyboardVisible) 
        {
            // Hide the bar
        }
        else
        {
            // Show the bar again
        }
    }

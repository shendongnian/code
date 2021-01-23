    if (rootFrame.Content == null)
    {
        // Default generated code
    }
    else
    {
        if (e.PreviousExecutionState == ApplicationExecutionState.Running)
        {
            if (!string.IsNullOrEmpty(e.Arguments))
                if (!rootFrame.Navigate(typeof (MainPage), e.Arguments))
                {
                     throw new Exception("Failed to create initial page");
                }
        }
    }
    
    // Ensure the current window is active.
    Window.Current.Activate();

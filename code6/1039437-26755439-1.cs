    #if WINDOWS_PHONE_APP
        if (!rootFrame.Navigate(typeof(PhonePage), e.Arguments))
        {
            throw new Exception("Failed to create initial page");
        }
    #endif
    #if WINDOWS_APP
        if (!rootFrame.Navigate(typeof(DesktopPage), e.Arguments))
        {
            throw new Exception("Failed to create initial page");
        }       
    #endif

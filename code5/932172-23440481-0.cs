    var frame = Window.Current.Content as Frame;
    if (frame != null)
    {
        var page = frame.Content as Page;
        if (page != null)
        {
            // you have found you page!
        }
        else
        {
            // the frame has not loaded a page yet - this isn't very likely to happen
        }
    }
    else
    {
        // the app is either not initialized yet
        // or you have modified the default template and Frame is not at the root.
    }

    public static void CloseForm()
    {
        // Loop for a maximum of 100ms if the screen hasn't yet been loaded.
        for (var i = 0; i < 100; i++)
        {
            if (loadingScreenForm != null && loadingScreenForm.IsHandleCreated)
            {
                break;
            }
            Thread.Sleep(1);
        }
        // Don't try to close if it is already closed.
        // If the screen form is still null after waiting, it was most likely already closed.
        if (loadingScreenForm != null && loadingScreenForm.IsHandleCreated)
        {
            loadingScreenForm.Invoke(new CloseDelegate(CloseFormInternal));
        }
    }

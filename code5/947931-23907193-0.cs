    /// <summary>
    /// Event raised when the window is about to close.
    /// </summary>
    private void Window_Closing(object sender, CancelEventArgs e)
    {
        ...
        //
        // When the window is closing, save AvalonDock layout to a file.
        //
        avalonDockHost.DockingManager.SaveLayout(LayoutFileName);
    }
...
    /// <summary>
    /// Event raised when AvalonDock has loaded.
    /// </summary>
    private void avalonDockHost_AvalonDockLoaded(object sender, EventArgs e)
    {
        if (System.IO.File.Exists(LayoutFileName))
        {
            //
            // If there is already a saved layout file, restore AvalonDock layout from it.
            //
            avalonDockHost.DockingManager.RestoreLayout(LayoutFileName);
        }
        else
        {
            //
            // ... no previously saved layout exists, need to load default layout ...
            //
        }
    }

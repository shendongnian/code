    void OnDisableTriggersPropertyChanged( object sender, EventArgs args )
    {
        // If IsDisposed property was changed and it is true now - cleanup triggers.
        if ((bool)args.NewValue)
        {
           var grid = (Grid)sender;
    
           // Ideally you can remove specific triggers. 
           // Clear all will work for simple cases.
           grid.Triggers.Clear();
        }
    }

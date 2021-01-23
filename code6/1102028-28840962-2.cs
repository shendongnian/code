    private void Initialize()
    {
        // AVTempUIPermission avtUIPermission = new AVTempUIPermission(AVTUIPermissionNewWindow.LaunchNewWindows);
        // CASRemoval:avtUIPermission.Demand();
 
        //  this makes MeasureCore / ArrangeCore to defer to direct MeasureOverride and ArrangeOverride calls
        //  without reading Width / Height properties and modifying input constraint size parameter...
        BypassLayoutPolicies = true;
 
        // check if within an app && on the same thread
        if (IsInsideApp == true)
        {
            if (Application.Current.Dispatcher.Thread == Dispatcher.CurrentDispatcher.Thread)
            {
                // add to window collection
                // use internal version since we want to update the underlying collection
                App.WindowsInternal.Add(this);
                if (App.MainWindow == null)
                {
                    App.MainWindow = this;
                }
            }
            else
            {
                App.NonAppWindowsInternal.Add(this);
            }
        }
    }

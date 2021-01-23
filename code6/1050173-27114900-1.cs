     private void OnLoadCompleted( object _sender )  
     {
       dockingManager.AutoHideAnimationStop += handler15;
    
     }
     private void handler15(object _sender, AutoHideAnimationEventArgs _arg)
     {
       ErrorListUserControl childControl = (ErrorListUserControl)errorListElementHost.Child;
       if ( errorListElementHost != null && childControl != null && errorListElementHost.Visible )
       {
         childControl.OnVisibilityChanged(_sender, _arg);
       }
     }

     private void OnLoadCompleted( object _sender )  
     {
       dockingManager.AutoHideAnimationStop += handler15;
    
     }
     private void handler15(object _sender, AutoHideAnimationEventArgs _arg)
     {
       MyUserControl childControl = (MyUserControl )MyElementHost.Child;
       if ( MyElementHost!= null && childControl != null && MyElementHost.Visible )
       {
         childControl.OnVisibilityChanged(_sender, _arg);
       }
     }

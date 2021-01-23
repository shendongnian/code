              dockingManager.DockControlActivated += handler1;
              dockingManager.DockControlDeactivated += handler2;
              dockingManager.DockMenuClick += handler3;
              dockingManager.DockStateChanged+=handler4;
              dockingManager.DockStateChanging += handler5;
              dockingManager.DockVisibilityChanged += handler6;
              dockingManager.DockVisibilityChanging += handler7;
              dockingManager.NewDockStateBeginLoad += handler8;
              dockingManager.NewDockStateEndLoad += handler9;
              dockingManager.DockAllow += handler10;
              dockingManager.ControlRestored += handler11;
              dockingManager.ControlMinimized += handler12;
              dockingManager.ControlMaximizing += handler13;
              dockingManager.ControlMaximized += handler14;
              dockingManager.AutoHideAnimationStop += handler15;
              dockingManager.AutoHideAnimationStart += handler16;
    }
    private void handler16(object sender, AutoHideAnimationEventArgs arg)
    {
      int i=0;i++;
    }
    private void handler15(object sender, AutoHideAnimationEventArgs arg)
    {
      int i=0;i++;
    }
    private void handler14(object sender, ControlMaximizedEventArgs args)
    {
      int i=0;i++;
    }
    ...

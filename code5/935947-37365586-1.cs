    KeepTransportControlsVisibleTimer = new DispatcherTimer();
    KeepTransportControlsVisibleTimer.Interval = TimeSpan.FromMilliseconds(10);
    KeepTransportControlsVisibleTimer.Tick += (obj, args) =>
    {
    VisualStateManager.GoToState(this, "ControlPanelVisible", true);
    };
    KeepTransportControlsVisibleTimer.Start();

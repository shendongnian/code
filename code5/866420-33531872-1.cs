    public void Initialize()
    {
            var wih = new WindowInteropHelper(this.mainWindow);
            this.hWndSource = HwndSource.FromHwnd(wih.Handle);
            this.globalMouseHook = Hook.GlobalEvents();
            this.mainWindow.CancellationTokenSource = new CancellationTokenSource();
            var source = this.hWndSource;
            if (source != null)
            {
                source.AddHook(this.WinProc); // start processing window messages
                this.hWndNextViewer = Win32.SetClipboardViewer(source.Handle); // set this window as a viewer
            }
            this.SubscribeLocalevents();
            this.growlNotifications.Top = SystemParameters.WorkArea.Top + this.startupConfiguration.TopOffset;
            this.growlNotifications.Left = SystemParameters.WorkArea.Left + SystemParameters.WorkArea.Width - this.startupConfiguration.LeftOffset;
            this.IsInitialized = true;
    }

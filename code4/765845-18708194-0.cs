    using MouseKeyboardActivityMonitor;
    using MouseKeyboardActivityMonitor.WinApi;
    using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
    
    private readonly MouseHookListener _mMouseHookManager;
    
    _mMouseHookManager = new MouseHookListener(new GlobalHooker()) {Enabled = true};
    _mMouseHookManager.MouseDown += HookManager_MouseDown;

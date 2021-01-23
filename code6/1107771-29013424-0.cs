    public MainWindow()
    {
        MouseDown += delegate { DragMove(); };
        InitializeComponent();
        _hookID = SetHook(_proc);
        CapsLockEnabled += (sender, e) => { Console.WriteLine("caps lock enabled"); };
    }

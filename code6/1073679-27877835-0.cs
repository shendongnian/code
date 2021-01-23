    public mainForm()
    {
        InitializeComponent();
        UserControl menuView = new mnlib.mnlibControl();
        newWindow(menuView);
        mnlibControl.OnLearnClick += new EventHandler(ButtonClick);
    }

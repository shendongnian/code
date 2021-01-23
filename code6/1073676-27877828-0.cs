    public mainForm()
    {
        InitializeComponent();
        UserControl menuView = new mnlib.mnlibControl();
        mnlibControl.LearnClick += new EventHandler(ButtonClick);
        newWindow(menuView);
    }

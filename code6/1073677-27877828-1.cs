    public mainForm()
    {
        InitializeComponent();
        UserControl menuView = new mnlib.mnlibControl();
        menuView.LearnClick += new EventHandler(ButtonClick);
        newWindow(menuView);
    }

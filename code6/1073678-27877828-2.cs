    public mainForm()
    {
        InitializeComponent();
        mnlib.mnlibControl menuView = new mnlib.mnlibControl();
        menuView.LearnClick += new EventHandler(ButtonClick);
        newWindow(menuView);
    }

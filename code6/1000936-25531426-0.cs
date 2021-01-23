    public MainPage()
    {
        this.InitializeComponent();
        this.DataContext = this;
        if (App.Current.RequestedTheme == ApplicationTheme.Dark)
        {
            myPage.RequestedTheme = ElementTheme.Dark;
        }
        else
        {
            myPage.RequestedTheme = ElementTheme.Light;
        }
    }

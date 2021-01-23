    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.Activated += Current_Activated;
    }
    private void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
    {
        Window.Current.Activated -= Current_Activated;
        Debug.WriteLine("Activated");
        WebAuthenticationBroker.AuthenticateAndContinue(new Uri("https://google.com"));
    }

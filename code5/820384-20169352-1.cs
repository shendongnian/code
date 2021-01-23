    public RegisterControl RegisterView { get; set; }
    public PlayerControl PlayerControlView { get; set; }
    public MainWindow()
    {
       RegisterView = new RegisterControl();
       PlayerControlView = new PlayerControl();
    }

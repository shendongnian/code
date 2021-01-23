    public MainPage()
   {
    this.InitializeComponent();
    Loaded += MainPage_Loaded;
    }
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
    CommandBar bottomCommandBar = this.BottomAppBar as CommandBar;
    AppBarButton appbarButton_0 = bottomCommandBar.PrimaryCommands[0] as AppBarButton;
    appbarButton_0.Label = "settings";
    appbarButton_0.Icon = new SymbolIcon(Symbol.Setting);
    }

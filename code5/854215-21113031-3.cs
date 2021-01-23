    private bool _contextMenuEnabled;
    public MainWindow()
    {
        _contextMenuEnabled = true;
        InitializeComponent();
        Button.ContextMenuOpening += Button_ContextMenuOpening;
    }
    void Button_ContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        e.Handled = !_contextMenuEnabled;
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        _contextMenuEnabled = !_contextMenuEnabled;
    }

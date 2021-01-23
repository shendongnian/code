    public MainPage()
    {
       InitializeComponent();
       ......
       ((MainViewModel)DataContext).Event1 += HandlerName;
       ......
    }

    public WorkspaceView()
    {
       InitializeComponent();
       // Something better than UserControl should be used here
       ObservableCollection<UserControl> views = new ObservableCollection<UserControl>();
       views.Add(new ViewA());
       views.Add(new ViewB());
       DataContext = views;
    }
    <Border ..>
        <TabControl x:Name="TabControl"
           ..
           ItemsSource="{Binding}" />
    </Border>

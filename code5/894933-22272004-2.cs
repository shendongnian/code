XAML
    <Grid>
        <local:ListViewCustomControl x:Name="MyListView" 
                                     Header="yolo" />
    </Grid>
Code-behind
    public MainWindow()
    {
        InitializeComponent();
        var data = new List<Type>();
        for (var i = 0; i < 123; i++)
            data.Add(new Type(i));
        MyListView.ElementsSource = data;
    }

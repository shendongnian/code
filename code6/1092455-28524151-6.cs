    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel
        {
            ImageItems = new ObservableCollection<ImageItem>()
        };
        vm.ImageItems.Add(new ImageItem
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 100,
                Image = new BitmapImage(new Uri(...))
            });
        DataContext = vm;
    }

    ObservableCollection<string> files; 
    public MainPage()
    {
        this.InitializeComponent();
        files = new ObservableCollection<string>();
    }
    private async void GetFiles(StorageFolder folder)
    {
        StorageFolder fold = folder;
        var items = await fold.GetItemsAsync();
        foreach (var item in items)
        {
            if (item.GetType() == typeof(StorageFile))
                files.Add(item.Path.ToString());
            else
                GetFiles(item as StorageFolder);
        }
        listView.ItemsSource = files;      
    }

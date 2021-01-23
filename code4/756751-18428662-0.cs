    public partial class MainPage : PhoneApplicationPage
    {
        const string MyDirectory = "offline";
        readonly string _offlineDataFile = Path.Combine(MyDirectory, "phones.json");
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            var data = await httpClient.GetStringAsync("http://www.tapanila.net/api/get_recent_posts/");
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            if (!store.DirectoryExists(MyDirectory))
            {
                store.CreateDirectory(MyDirectory);
            }
            using (var fileStream = new IsolatedStorageFileStream(_offlineDataFile, FileMode.Create, store))
            {
                using (var stream = new StreamWriter(fileStream))
                {
                    stream.Write(data);
                }
            }
            LoadOffline();
        }
        private void LoadOffline()
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            using (var fileStream = new IsolatedStorageFileStream(_offlineDataFile, FileMode.Open, store))
            {
                using (var stream = new StreamReader(fileStream))
                {
                   var data = stream.ReadToEnd();
                }
            }
        }
    }

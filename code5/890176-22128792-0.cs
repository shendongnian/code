       public MainPage()
        {
            InitializeComponent();
    
            Browser.Navigate(new Uri("http://example.com/test.txt"));
        }
    
        private void Browser_Navigated(object sender, NavigationEventArgs e)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            var filename = "InTheRoot.txt";
    
            if (store.FileExists(filename)) store.DeleteFile(filename);
    
            using (var stream = store.CreateFile(filename))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(Browser.SaveToString());
                }
            }
    
            using (var file = store.OpenFile(filename, FileMode.Open))
            {
                using(var reader = new StreamReader(file))
                {
    	            Text.Text = reader.ReadToEnd();
                }
            }
        }

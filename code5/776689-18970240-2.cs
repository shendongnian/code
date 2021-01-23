    public partial class MyPage : PhoneApplicationPage
    {
        public MyPage()
        {
            InitializeComponent();
            this.Loaded += async (sender, e) =>
            {
                var folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("Pictures");
                var images = await folder.GetFilesAsync();
                Recent.ItemsSource = images.ToList();
            };
        }
    }

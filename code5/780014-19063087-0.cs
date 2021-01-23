    public sealed partial class MainPage : Page
    {
        MediaCapture mediaCapture;
        IRandomAccessStream randomAccessStream;
        public MainPage()
        {
            this.InitializeComponent();
            mediaCapture = new MediaCapture();
            randomAccessStream = new InMemoryRandomAccessStream();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            await mediaCapture.InitializeAsync();
            MediaEncodingProfile profile = MediaEncodingProfile.CreateWmv(VideoEncodingQuality.Auto);
            await mediaCapture.StartRecordToStreamAsync(profile, randomAccessStream);
        }
        private async void StropButton_Click(object sender, RoutedEventArgs e)
        {
            await mediaCapture.StopRecordAsync();
            await randomAccessStream.FlushAsync();
            randomAccessStream.Seek(0);
            // want to convert this randomAccessStream into byte[]
            mediaElement.SetSource(randomAccessStream, "video/x-ms-wmv");
        }
    }

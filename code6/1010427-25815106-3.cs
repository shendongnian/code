    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void web()
        {
            String url = "http://8tracks.com/mix_sets/all.json?include=mixesapi_key=05570e44383665661d8edeeb5d4f07d415e14b4a";
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            xt.Text = result;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            web();
        }
    }

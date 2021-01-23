    public class ListViewPage : ContentPage
    {
        private readonly ListView listView;
        public ListViewPage()
        {
            Title = "Users";
            this.listView = new ListView {ItemTemplate = new DataTemplate(typeof (TextCell))};
            this.listView.ItemTemplate.SetBinding(TextCell.TextProperty, "username");
            Content = new StackLayout
            {
                Children = { this.listView }
            };
            var sv = new RestClient();
            var es = sv.GetUsersAsync().ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Debug.WriteLine("Found {0} users.", t.Result.Length);
                    Device.BeginInvokeOnMainThread(() => this.listView.ItemsSource = t.Result);
                }
            });
        }
    }

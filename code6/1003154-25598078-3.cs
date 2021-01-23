    public class sample_data
    {
        public sample_data(string artist, string song)
        {
            this.Artist = artist;
            this.Song = song;
        }
        public string Artist { get; set; }
        public string Song { get; set; }
    }
    private ObservableCollection<sample_data> CreateData()
    {
        //List<sample_data> my_list = new List<sample_data>();
        ObservableCollection<sample_data> my_list = new ObservableCollection<sample_data>();
        my_list.Add(new sample_data("Faith + 1", "Body of Christ"));
        my_list.Add(new sample_data("Faith + 1", "Christ Again"));
        my_list.Add(new sample_data("Faith + 1", "A Night With the Lord"));
        my_list.Add(new sample_data("Faith + 1", "Touch Me Jesus"));
        my_list.Add(new sample_data("Faith + 1", "I Found Jesus (With Someone Else)"));
        my_list.Add(new sample_data("Faith + 1", "Savior Self"));
        my_list.Add(new sample_data("Faith + 1", "Christ What a Day"));
        my_list.Add(new sample_data("Faith + 1", "Three Times My Savior"));
        my_list.Add(new sample_data("Faith + 1", "Jesus Touched Me"));
        my_list.Add(new sample_data("Faith + 1", "Lord is my Savior"));
        my_list.Add(new sample_data("Faith + 1", "I Wasn't Born Again Yesterday"));
        my_list.Add(new sample_data("Faith + 1", "Pleasing Jesus"));
        my_list.Add(new sample_data("Faith + 1", "Jesus (Looks Kinda Hot)"));
        my_list.Add(new sample_data("Butters", "What What"));
        return my_list;
    }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ObservableCollection<sample_data> sd = this.CreateData();
        mylistview.ItemsSource = sd;
    }

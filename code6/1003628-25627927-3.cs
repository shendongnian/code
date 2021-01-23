    public class sample_viewmodel
    {
        public sample_viewmodel()
        {
            this.DataSource = CreateData();
            this.SimpleCommand = new MySimpleCommand();  // create the command
        }
        // create a static list for our demo
        private ObservableCollection<sample_model> CreateData()
        {
            ObservableCollection<sample_model> my_list = new ObservableCollection<sample_model>();
            my_list.Add(new sample_model("Faith + 1", "Body of Christ", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Christ Again", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "A Night With the Lord", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Touch Me Jesus", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "I Found Jesus (With Someone Else)", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Savior Self", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Christ What a Day", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Three Times My Savior", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Jesus Touched Me", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Lord is my Savior", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "I Wasn't Born Again Yesterday", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Pleasing Jesus", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Jesus (Looks Kinda Hot)", "A Track"));
            my_list.Add(new sample_model("Butters", "What What", "B Track"));
            return my_list;            
        }
        public ICommand SimpleCommand { get; set; }
        public ObservableCollection<sample_model> DataSource{ get; set; }
    }

    public class MyViewModel
    {
        public MyViewModel()
        {
            this.Items = new ObservableCollection<MyModel>();
            this.Field1Items = new ObservableCollection<string>() { "1", "2", "3" };
            AddCommand = new RelayCommand(o => true, o => Items.Add(new MyModel()));
        }
    
        public ObservableCollection<MyModel> Items { get; set; }
    
        public ObservableCollection<string> Field1Items { get; set; }
    
        public RelayCommand AddCommand { get; set; }
    }

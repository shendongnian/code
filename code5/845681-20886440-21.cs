    public class MyViewModel
    {
        public MyViewModel()
        {
            this.Items = new ObservableCollection<IModel>();
            this.Field1Items = new ObservableCollection<string>() { "1", "2", "3" };
            AddTitleCommand = new RelayCommand(o => true, o => Items.Add(new MyTitleModel()));
            AddQuestionCommand = new RelayCommand(o => Items.Any(), o =>
            {
                var title = this.Items.OfType<MyTitleModel>().LastOrDefault();
                Items.Add(new MyQuestionModel() { Title = title });
            });
        }
        public ObservableCollection<IModel> Items { get; set; }
        public ObservableCollection<string> Field1Items { get; set; }
        public RelayCommand AddTitleCommand { get; set; }
        public RelayCommand AddQuestionCommand { get; set; }
    }

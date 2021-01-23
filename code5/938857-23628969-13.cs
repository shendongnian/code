    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DeleteCommand = new DelegateCommand(x => DeleteSelectedItem(null));
            People = new ObservableCollection<Person>();
            DataContext = this;
            Loaded += (sender, args) => PopulateCollection();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void PopulateCollection()
        {
            People.Add(new Person { Forename = "Bob", Surname = "Smith" });
            People.Add(new Person { Forename = "Alice", Surname = "Jones" });
        }
        private void DeleteSelectedItem(object obj)
        {
            People.Remove(SelectedItem);
            SelectedItem = null;
        }
        public ICommand DeleteCommand { get; set; }
        public ObservableCollection<Person> People { get; set; }
        private Person selectedItem;
        public Person SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

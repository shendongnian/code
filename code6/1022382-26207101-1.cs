    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Person> personList;
        public ObservableCollection<Person> PersonList
        {
            get { return personList; }
            set
            {
                if (value == personList)
                    return;
                personList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PersonList"));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            PersonList = new ObservableCollection<Person>();
            // etc.
        }
    }

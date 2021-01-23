    public MainWindow()
        {
            PersonList = new ObservableCollection<Person>();
            InitializeComponent();
            PersonList.Add(new Person(16, "Abraham", "Lincoln"));
            PersonList.Add(new Person(32, "Franklin", "Roosevelt"));
            PersonList.Add(new Person(35, "John", "Kennedy"));
            PersonList.Add(new Person(2, "John", "Adams"));
            PersonList.Add(new Person(1, "George", "Washington"));
            PersonList.Add(new Person(7, "Andrew", "Jackson"));
           
        }

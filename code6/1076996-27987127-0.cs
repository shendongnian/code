    private readonly ObservableCollection<Person> _persons = new ObservableCollection<Person>();
    public ObservableCollection<Person> persons { get { return _persons; } }
    
    public MainWindow()
    {
        InitializeComponent();      
        persons.Add(new Person { Name = "Peter" });
    }

    public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                ObservableCollection<Activity> hobbys = new ObservableCollection<Activity>();
                hobbys.Add(new Activity() { Name = "Soccer" });
                hobbys.Add(new Activity() { Name = "Basketball" });
                Community = new ObservableCollection<Person>();
                Community.Add(new Person() { Name = "James", Hobbys = hobbys });
                Community.Add(new Person() { Name = "Carl", Hobbys = hobbys });
                Community.Add(new Person() { Name = "Homer", Hobbys = hobbys });
                MyGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("Name") });    //Static Column
                int x = 0;
                foreach (Activity act in Community[0].Hobbys)  //Create the dynamic columns
                {
                    MyGrid.Columns.Add(new DataGridTextColumn() { Header = "Activity", Binding = new Binding("Hobbys["+x+"].Name") });
                    x++;
                }
    
            }

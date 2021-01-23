        public ViewModel()
        {
            AddItem = new SimpleCommand(i => List.Add(new Person()));
            List = new ObservableCollection<object>(new[] { new Person() { Name = "a person"} });
        }
        public ObservableCollection<object> List { get; set; }
        class Person
        {
            public string Name { get; set; }
        }
        public ICommand AddItem { get; set; }

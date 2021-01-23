        class MyListsOfLists
    {
        public ObjectLists AllLists { get; set; }
    }
    class ObjectLists
    {
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Dog> Dogs { get; set; }
        public List<Car> Cars { get; set; }
        public List<House> Houses { get; set; }
    }
    class Adult
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
    class Child
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
    class Dog
    {
            public int ID { get; set; }
            public string Name { get; set; }
            public DateTime DOB { get; set; }
    }
    class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ModelYear { get; set; }
    }
    class House
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Built { get; set; }
    }

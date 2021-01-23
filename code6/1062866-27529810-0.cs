    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class DataSource
    {
        public void Save(Person p)
        {
           // save person to database
        }
        public Person LoadById(int id)
        {
           // load person from database
        }
    }

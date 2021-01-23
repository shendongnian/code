    class Employee
    {
        Person person = new Person();
    
        public string Name 
        {
            get { return person.Name; }
            set { person.Name = value } 
        }
        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }
    }

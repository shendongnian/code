        public List<Person> People
        {
            get {
                List<Person> retVal = new List<Person>();
                retVal.Add(new Person() { Id = 1, FirstName = "John", LastName = "Lenon" });
                retVal.Add(new Person() { Id = 2, FirstName = "Ringo", LastName = "Star" });
                retVal.Add(new Person() { Id = 3, FirstName = "Paul", LastName = "Mc Cartney" });
                retVal.Add(new Person() { Id = 4, FirstName = "George", LastName = "Harrison" });
                return retVal;
            }
        }

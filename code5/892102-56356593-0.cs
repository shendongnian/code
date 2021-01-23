     public class Person
    {
        public int ID { get; set; }
        // following 2 lines are cause of error
        //public string Name { get { return string.Format("{0} {1}", First, Last); } }
        //public string Country { get { return Countries[CountryID]; } }
        public int CountryID { get; set; }
        public bool Active { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public DateTime Hired { get; set; }
    }
    public class ModelObj
        {
            public string Str { get; set; }
            public List<Person> Persons { get; set; }
        }

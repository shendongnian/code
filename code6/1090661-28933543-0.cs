    public class CustomPerson
    {
        public string Key { get; set; }
        public Person Person { get; set; }
        public string DisplayValue
        {
            get { return Person.FirstName; }
        }
    }

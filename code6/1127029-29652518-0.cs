    public class person
    {
        private string name { get; set; };
        public string surname { get; set; };
        private int year { get; set; };
    
        public person(string name, int year)
        {
            this.name = name;
            this.year = year;
        }
    }
    public class student : person
    {
        public student(string name, int year) : base (name, year) { };
    }

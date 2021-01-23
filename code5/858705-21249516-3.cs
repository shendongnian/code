    public class StudentData
    {
        string name;
        string age;
        string address;
        string bday;
        string level;
    
        [FixedLengthDelimeter(0, 20)]
        public string Name { get { return this.name; } set { this.name = value; } }
            
        [FixedLengthDelimeter(1, 3)]
        public string Age { get { return this.age; } set { this.age = value; } }
            
        [FixedLengthDelimeter(2, 30)]
        public string Address { get { return this.address; } set { this.address = value; } }
            
        [FixedLengthDelimeter(3, 10)]
        public string BDay { get { return this.bday; } set { this.bday = value; } }
    
        [FixedLengthDelimeter(4, 3)]
        public string Level { get { return this.level; } set { this.level = value; } }
    }

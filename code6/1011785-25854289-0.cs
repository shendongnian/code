    public class Faculty
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public string[] subInterest = new string[4];
    
        public Faculty(string name, string dept, string[] si)
        {
            this.Name = name;
            this.Dept = dept;
            this.subInterest = si;
        }
    }

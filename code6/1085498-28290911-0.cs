    public class Student
    {
        private string _name;
        public string Name
        { 
            get { return _name; } 
            set { if (value != null) _name = value; }
        }
        public int Marks { get; set; }
        public Student()
        {
            Name = "<No Name>";
        }
        public override string ToString()
        {
            return string.Format("{3}Name:{0}{3}Marks:{1}", 
                Name, Marks, Environment.NewLine));
        }
    }

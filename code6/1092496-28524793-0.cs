    public class Student_APP
    {
        // Public properties with get/set and an automatic backing field
        public int score1 {get; set;}
        public int score2 {get; set;}
        public int score3 {get; set;}
        public string major {get; set;}
        
        // Internal properties
        private int _id;
        private string _surname;
        private string _name;
        public Student()
        {}
        public Student(int idnumber)
        {
            _id = idnumber;
        }
        public Student(int idnumber, string surname, string name)
        {
            _id = idnumber;
            _surname = surname;
            _name = name;
        }
    }

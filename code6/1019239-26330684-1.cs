    namespace StudentPresentationGUI
    {
        public class Student
        {
            public string name;
        }
        //CHANGES HERE
        public Student(string _name) 
        {
            name = _name;
        }
    }
/
    namespace StudentPresentationGUI
    {
    public class UnderGraduate : Student
    {
        private string classification;
        private string guardianname;
        private string address;
    
        //CHANGES HERE (Look to the right)
        public UnderGraduate(string classif, string guardian, string addr, string _name) : base(_name) 
        {
            classification = classif;
            guardianname = guardian;
            address = addr;
        }
    
        UnderGraduate()
        {
    
        }
    
        protected string getClassification()
        {
            return classification;
        }
    
        protected string getGuardianName()
        {
            return guardianname;
        }
    
        protected string getAddress()
        {
            return address;
        }
    
    }}

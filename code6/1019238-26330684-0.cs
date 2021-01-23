    namespace StudentPresentationGUI
    {
        public class Student
        {
            public string name;
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
    
        //CHANGES HERE
        public UnderGraduate(string classif, string guardian, string addr, string _name) 
        {
            classification = classif;
            guardianname = guardian;
            address = addr;
            name = _name;
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

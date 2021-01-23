    public class Website
    {
        public string blog { get; set; }
    }
    
    public class Department
    {
        public string name { get; set; }
        public string location { get; set; }
    }
    
    public class Faculty
    {
        public List<Department> department { get; set; }
    }
    
    public class RootObject
    {
        public string name { get; set; }
        public List<string> email { get; set; }
        public Website website { get; set; }
        public Faculty faculty { get; set; }
    }

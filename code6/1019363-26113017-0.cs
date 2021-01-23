    public class Clazz
    {
        public string className { get; set; }
        public Division[] Division { get; set; }
    }
    
    public class Division
    {
        public string name { get; set; }
        public Subject[] subject { get; set; }
    }
    
    public class Subject
    {
        public string name { get; set; }
    }

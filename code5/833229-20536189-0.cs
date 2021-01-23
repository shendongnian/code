    public class Redteam
    {
        public List<string> banname { get; set; }
        public List<int> bannumber { get; set; }
        public List<string> players { get; set; }
        public List<double> pickrate { get; set; }
        public List<int> picknumber { get; set; }
        public string team { get; set; }
        public List<string> pickname { get; set; }
        public List<double> pickwinrate { get; set; }
    }
    
    public class Blueteam
    {
        public List<string> banname { get; set; }
        public List<int> bannumber { get; set; }
        public List<string> players { get; set; }
        public List<double> pickrate { get; set; }
        public List<int> picknumber { get; set; }
        public string team { get; set; }
        public List<string> pickname { get; set; }
        public List<double> pickwinrate { get; set; }
    }
    
    public class RootObject
    {
        public Redteam redteam { get; set; }
        public Blueteam blueteam { get; set; }
    }

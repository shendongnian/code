    public class ClsDictionary
    { 
        public Dictionary<string, string> Details { private get; set; }
    
        public  ClsDictionary()
        {
            Details = new Dictionary<string, string>();
        }
        public  ClsDictionary(Dictionary<string, string> details)
        {
            Details = details;
        }
    }

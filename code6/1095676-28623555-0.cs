    public class ClsDictionary
    { 
        private Dictionary<string, string> Details;
        public ClsDictionary() 
            : this(new Dictionary<string, string>())
        {
        }
    
        public ClsDictionary(Dictionary<string, string> details)
        {
            this.Details = details;
        }
    
        public Dictionary<string, string> getDictionary()
        {
            return this.Details;
        }
    }

    public class customers
    {
        private List<String> _dates = new List<String>();
        private List<String> _description = new List<String>();
    
        public List<String> Dates
        { 
            { return _dates; }
            { _dates = value; }
        }
       
        public List<String> Description
        { 
            { return _description; }
            { _description = value; }
        }
           
        ....

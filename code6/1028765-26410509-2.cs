    public class DataWithTimestamp
    {
        public string line {get;set;}
        public DateTime stamp {get;set;}
    
        public DataWithTimestamp(string data)
        {
            stamp = regex.extract(pattern); // not the correct syntax, set it here
            line = data;
        } 
    }

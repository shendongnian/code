    public class Book
    {       
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }       
        
        [ScriptIgnore]
        public string AuthorName { get; set; }
        
        [ScriptIgnore]
        public int AuthorAge { get; set; }
    
        [ScriptIgnore] 
        public string AuthorCountry { get; set; }
    }

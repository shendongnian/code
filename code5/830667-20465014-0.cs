    public class AModel 
    {
       public string Name { get; set; }
       public LanguageModel Lang { get; set; }
    }
    
    public class LanguageModel
    {
        // No ID
        public string Eng { get; set; }
        public string Fra { get; set; }
        public string Ned { get; set; }
        ...
    }

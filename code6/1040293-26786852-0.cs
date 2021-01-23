    public class Referancial
    {
        // Identity
        public int KeyID { get; set; }
    
        public string Code { get; set; }
    
        public virtual ICollection<Translation> Translations { get; set; }
    
    }
    
    public class Translation
    {
        //Translation needs its own Key
        public int ID { get; set; }
        // reference directly the Referencial object instead of the ID
        public Referencial Referencial { get; set; }
    
        public int LanguageID { get; set; }
    
        public string Label { get; set; } 
    }

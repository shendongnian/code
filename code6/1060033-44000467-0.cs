    public class Farm
    {
        [DisplayName("Cow")]
        public Animal Cow1 {get;set;}
        [DisplayName("Pig")]
        public Animal Pig1 {get;set;} 
    }
    
    public class Animal
    {
        public string Name {get;set;}
    }

    public class User{
    
       public int ID { get;set; } 
       public virtual ICollection<Animal> Animals {get;set;} 
    
    }
    
    
    public class Animal{
        public int ID { get; set; }
        public string Name {get;set;}
        [ForeignKey("Owner")]
        public int? Owner_ID {get;set;}
        public virtual User Owner {get;set;}
    }

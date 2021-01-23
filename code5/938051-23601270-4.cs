     public class Princess 
     { 
         public int Id { get; set; } 
         public string Name { get; set; } 
         public virtual ICollection<Unicorn> Unicorns { get; set; } 
     }

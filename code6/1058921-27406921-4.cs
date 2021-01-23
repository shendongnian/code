    public class Car {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Tyre> Tires { get; set; }
    }
    public class Tyre {
        public virtual int Id { get; set; }
        
        // More properties...
    
        [ForeignKey("CarId")]
        public virtual int CarId { get; set; }
        public virtual Car Car { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }
    
        public string BrandId { get; set; }
        [NotMapped]
        public Metadata Brand { get; set; }
    
        public string ModelId { get; set; }
        [NotMapped]
        public Metadata Model { get; set; }
    
        public string ColorId { get; set; }
        [NotMapped]
        public Metadata Color { get; set; }
    }

    public class CarModel
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public string Name { get; set; }
        [Key, ForeignKey("Brand"), Column(Order=1)]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }

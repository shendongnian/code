    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Url)]
        [Display(Name = "Producer")]
        public string ManufacturerUrl { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Display(Name = "In stock")]
        public int Stock { get; set; }
        public CategoryViewModel Category { get; set; }
    }

    public class ProductVM
    {
      public int ProductID { get; set; }
      [Required]
      public string Name { get; set; }
      [Required]
      public int? ShopID { get; set; }
      [Required]
      public double Price { get; set; }
      public SelectList ShopList { get; set; }
    }

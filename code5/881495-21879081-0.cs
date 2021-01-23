    public class OrderDetailViewModel
    {
      public int OrderId { get; set; }
      public int ProductId { get; set; }
      public decimal UnitPrice { get; set; }
      public int Quanity { get; set; }
      public decimal Discount { get; set; }
    }
    public class OrderDetailsViewModel
    {
      public OrderDetailsViewModel()
      {
          OrderDetails = new List<OrderDetailsViewModel>();
      }
      public List<OrderDetailsViewModel> OrderDetails { get; set; }
    }

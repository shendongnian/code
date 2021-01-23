    public class PurchaseItemViewModel
    {
      public string ItemName { get; set; }
      public decimal Cost { get; set; }
      public string Category { get; set; }
      public IEnumberable<SelectListItem> Categories { get; set; }
    }

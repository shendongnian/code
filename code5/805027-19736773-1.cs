    public class PurchaseItemViewModel
    {
      public string ItemName { get; set; }
      public decimal Cost { get; set; }
      public string Category { get; set; }
      public IEnumberable<Category> Categories { get; set; }
      public PurchaseItemViewModel(PurchaseItemModel items, List<Cateory> categories)
      {
           //initialize items and catories
      }
    }

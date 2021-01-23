    public class PurchaseItemViewModel
    {
      public string ItemName { get; set; }
      public decimal Cost { get; set; }
      public string Category { get; set; }
      public IEnumberable<Category> Categories { get; set; }
      public PurchaseItemViewModel(PurchaseItemModel item, List<Category> categories)
      {
           //initialize item and categories
      }
    }

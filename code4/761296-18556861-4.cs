    public class ItemProduction
    {
       public string Main { get; set; }
       public DateTime TtemDate { get; set; }
       public string ItemType { get; set; }
       public string ProductionId { get; set; }
       public int Quantity { get; set; }
       public string Status { get; set; }
       
       public ItemProduction()
       {
           this.Main = string.Empty;
           this.ItemDate = DateTime.UtcNow;
           this.ItemType = string.Empty;
           this.ProductionId = string.Empty;
           this.Quantity = 0;
           this.Status = string.Empty;
       }
    }

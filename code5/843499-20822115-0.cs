    public class Sale
    {
       public int Quantity { get; set; }
    
       public int Price { get; set; }
    
       private int total;
    
       public int Total
       {
          get
          {
            return this.Quantity * this.Price;
          }
       }
    }

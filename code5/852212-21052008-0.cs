    public class Waiver
    {
       public string Id { get; set; }
       public int Type { get; set; }
       public decimal Amount { get; set; }
    
       public decimal GetWaivedPrice(decimal unitPrice, int qty) { ... }
    
    }

    public class Report
    {
       [Key(Order=0)]
       public int ProductId { get; set; }
    
       [Key(Order=1)]
       public int MonthId { get; set; }
    
       public Product product { get; set; }
    
       public Month month { get; set; }
    
       public decimal Price { get; set; }
    }

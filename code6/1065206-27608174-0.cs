    public class TableA {
    
      [Key, Column(Order=0)]
      public int itemCode { get; set; }
    
      [Key, Column(Order=1)]  
      public int itemCategoryCode { get; set; }
     
      public virtual ICollection<TableB> TableBs { get; set; }
    }

    public class TableB {
    
      [Key]
      public int ID { get; set; }
      [ForeignKey("TableARecord"), Column(Order=1)]
      public int itemCode { get; set; }
    
      [ForeignKey("TableARecord"), Column(Order=2)]  
      public int itemCategoryCode { get; set; }
    
      public virtual TableA TableARecord { get; set; }
    
    }

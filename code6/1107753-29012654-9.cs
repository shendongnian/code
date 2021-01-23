    public class CODES
    {
      [Key]
      public string CODE { get; set; }
      
      [Required]
      public virtual AGGREGATIONS Aggregation { get; set; }
      public ICollection<AGGREGATION_CHILDS> AggregationChilds { get; set; }
    }
    public class AGGREGATIONS
    {
       [Key]
       public int ID_AGGREGATION { get; set; }
     
       public byte CODE_LEVEL { get; set; }
       public virtual CODES Code { get; set; }
       public ICollection<AGGREGATION_CHILDS> AggregationChilds { get; set; }
    }
    
    public class AGGREGATION_CHILDS
    {
       [Key,Column(Order = 0),ForeignKey("Code")]
       public string CODE { get; set; }
   
       [Key,Column(Order = 1),ForeignKey("Aggregation")]
       public int ID_AGGREGATION { get; set; }
       public virtual CODES Code { get; set; }
       public virtual AGGREGATIONS Aggregation { get; set; }
    }

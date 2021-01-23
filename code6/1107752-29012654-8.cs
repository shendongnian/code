    public class CODES
    {
      [Key]
      public string CODE { get; set; }
      [ ... ]
      public virtual AGGREGATIONS Aggregation { get; set; }
    }
    public class AGGREGATIONS
    {
       [Key, ForeignKey("Codes")]
       public string CODE { get; set; }
       public byte CODE_LEVEL { get; set; }
       public virtual CODES Code { get; set; }
    }

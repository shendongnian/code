    public class TableA
    {
      [Key]
      public Guid Id { get; set; }
      public virtual TableB TableB { get; set; }
      public virtual TableC TableC { get; set; }
    }
    public class TableB
    {
      [Key]
      [ForeignKey("TableA")]    
      public Guid Id { get; set; }
      public virtual TableA TableA { get; set; }
      [ForeignKey("TableC")]    
      public Guid TableCId { get; set; }
      public virtual TableC TableC { get; set; }
    }
    public class TableC
    {
      [Key]
      public Guid Id { get; set; }
    }

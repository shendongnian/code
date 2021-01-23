    public class MyTable
    {
      [Key, Column(Order = 0)]
      public int SomeId { get; set; }
      [Key, Column(Order = 1)]
      public int OtherId { get; set; }
    }

    public class Table
    {
      [StringLength(20)]  // <-- hint: int doesn't need a string-length limitation
      public int Ref {get;set;}
    }

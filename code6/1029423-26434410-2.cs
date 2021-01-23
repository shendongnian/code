    public class MyClass
    {
      [Column("ColumnName")]
      public int PropertyName { get; set; }   
    }
    var result = GetColumnName<MyClass>("PropertyName");
    Console.WriteLine(result);

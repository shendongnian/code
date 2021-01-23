    public class MyClass
    {
      public int PropertyName { get; set; }   
    }
    var result = GetPropertyNames<MyClass>();
    Console.WriteLine(result.First());

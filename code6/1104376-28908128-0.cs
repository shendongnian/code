    public class MyClass {
       public int A { get; set; }
       public int B { get; set; }
       ...other stuff...
    
       public IEnumerable<int> GetIntValues()
       {
           yield return A;
           yield return B;
       }
    }

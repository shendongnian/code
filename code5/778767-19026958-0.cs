    public class MyClass 
    {
      public string Name {get; set;}
   
      public string Method()
      {
        string Name; // hides the class level property
        ....
      }
    }

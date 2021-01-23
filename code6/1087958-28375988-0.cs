    public class Example
    {
          private string id;
          public Example(string id)
          {
              this.id = id;
          }
      
          public void Test()
          {
               // Holds initial value from Constructor.
               Console.WriteLine(id);
    
               // Modified to new value.
               id = "7";
               Console.WriteLine("7");
          }
    }

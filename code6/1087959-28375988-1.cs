    public class Container
    {
         public string Id {get; set; }
    }
    
    public class Example
    {
         private Container container;
         public Example(Container container)
         {
              this.container = container;
         }
    
         public void Tester()
         {
              // Same Value when object created.
              Console.WriteLine(container.Id);
    
              // Modified Value:
              container.Id = "New Value";
         }
    }

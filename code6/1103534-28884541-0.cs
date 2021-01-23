    public class Example
    {
         private string example;
         public Example(string example)
         {
             this.example = example;
         }
    
         public string Demo
         {
              get { return example; }
              private set { example = value; }
         }
    }

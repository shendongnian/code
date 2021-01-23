    private class SubExampleClass
    {
         private object SubExampleClassPrivate;
         private readonly SubSubExampleClass SubSubExampleClassPublic;
         private readonly ExampleClass parent;
         public SubExampleClass(ExampleClass parent)
         {
             // save reference to the parent object
             this.parent = parent; 
             // pass it to subclass
             SubSubExampleClassPublic= new SubSubExampleClass(parent)
         }
        .
        .
        .
    }
    public class SubSubExampleClass
    {
         private readonly ExampleClass parent;
    
         public SubSubExampleClass(ExampleClass parent)
         {
             this.parent = parent; // save reference to the parent object
         }
         public void DoSomething()
         {
             //Do something within SubSubExampleClass
             parent.ChangeExampleClassPrivate;
         }
    }

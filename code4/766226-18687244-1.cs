    abstract class BaseEntry<T>
    {
       public T Value {get; set;}
       public string Name {get; set;}
       public abstract void Display();
    }
    class BoolEntry : BaseEntry<bool>
    {
         public override void Display()
         {
             // Your code here
         }
    }
    

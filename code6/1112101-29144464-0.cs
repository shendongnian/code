    class Program
       {
           static void Main(string[] args)
           {
               var thing = new Thing();
               var otherThing = new OtherThing();
               thing.Accept(otherThing);
               Console.WriteLine(thing.I);
               Console.Read();
           }
       }
    
       class OtherThing
       {
           public void Change(Action<int> setI)
           {
               setI(42);
           }
       }
    
       class Thing
       {
           private int i;
    
           public int I { get { return i; } }
           
           public void Accept(OtherThing visitor)
           {
               visitor.Change(SetI);
           }
    
           private void SetI(int i)
           {
               this.i = i;
           }
       }

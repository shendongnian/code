    namespace Library
    {
        public class Bar
        {
             // whatever inside
        }
        public class Foo
        {    
             public Bar BarMember { get; private set; }
             public Foo()
             {
                 BarMember = new Bar();    
             }
        }
    }
    
    
    
     namespace Project1
     {
         class Program
         {
             static void Main(string[] args)
             {
                 Foo foo = new Foo();
                 // foo.BarMember is accessible here
             }
         }
     }

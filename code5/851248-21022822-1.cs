    abstract class Foo
    {
       public virtual bool IsIt() {return true;}
    }
    
    class Bar
    {
       public bool CanIt(Foo foo)
       {
           return foo.IsIt();
       }
    }

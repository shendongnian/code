    // marker interface
    public interface FooBar
    {
    }
    
    public interface Fooable:FooBar
    { void Foo(); }
    
    public interface Barrable:FooBar
    { void Bar(); }
    
    
    public class FooBarProcessor
    {
        public void ProcessFooBars(IList<FooBar> foobars)
        {
            foreach(var foobar in foobars)
            {
               // feature detection to see which interfaces the instance implements
               IBarrable bar = foobar as IBarrable;
               if(bar != null)
                   bar.Bar();
    
               IFooable foo = foobar as IFooable;
               if(foo != null)
                   foo.Foo();
            }
        }
    }

    // marker interface
    public interface IFooBar
    {
    }
    
    public interface IFooable:IFooBar
    { void Foo(); }
    
    public interface IBarrable:IFooBar
    { void Bar(); }
    
    
    public class FooBarProcessor
    {
        public void ProcessFooBars(IList<IFooBar> foobars)
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

    public interface IFooable : IFooBar, IOutOfMyControlFooable
    { void Foo(); }
    
    public interface IBarrable : IFooBar, IOutOfMyControlBarrable
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

    public interface IFooFactory
    {
    	IFoo CreateFoo(string bar);
    	IFoo CreateFoo();
    }
    
    public interface IFoo
    {
    	string Bar { get; set; }
    }
    
    public class Foo : IFoo
    {
    	public string Bar { get; set; }
    
    	public Foo(string bar)
    	{
    		Bar = bar;
    	}
    }
        
    kernel.Bind<IFoo>().To<Foo>().InSingletonScope();
    kernel.Bind<IFooFactory>().ToFactory();
            
    IFoo foo1 = fooFactory.CreateFoo("myBar");
    IFoo foo2 = fooFactory.CreateFoo("myDifferentBar"); // value is basically ignored here
    IFoo foo3 = fooFactory.CreateFoo();

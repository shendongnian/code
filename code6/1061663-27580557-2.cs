    public interface IFoo
    {
    	DateTime ResolvedTime {get; set;}
    }
    
    public class Foo: IFoo
    {
    	public DateTime ResolvedTime {get; set;}
    }
    //Can be registered using a lambda as in:
    container.RegisterType<IFoo,Foo>(
                 new InjectionFactory(c => new Foo{ ResolvedTime = DateTime.Now }));

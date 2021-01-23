    public interface IComposition<T>
    {
    	T Dependency { get; set; }
    }
    
    public class MyClass: IComposition<TypeA>, IComposition<TypeB>
    {
    	IComposition<TypeA>.TypeA Dependency { get; set; }
    	IComposition<TypeB>.TypeB Dependency { get; set; }
    }

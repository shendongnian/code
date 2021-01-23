    public interface IBaseInterface  { }
    public interface IInterfaceA { }
    public interface IInterfaceB { }
    
    public class Test<T> where T : IBaseInterface
    {
    
    }
    
    var a = new Test<IBaseInterface>();

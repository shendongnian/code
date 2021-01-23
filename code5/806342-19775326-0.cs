    void Main()
    {
        var supportedInterfaces =
            from intf in typeof(Test).GetInterfaces()
            where intf.IsGenericType
            let genericIntf = intf.GetGenericTypeDefinition()
            where genericIntf == typeof(ISurface<>)
            select intf;
    
        supportedInterfaces.Dump();
    }
    
    public class Test : ISurface<int>
    {
    }
    
    public interface ISurface<T>
    {
    }

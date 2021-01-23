    [ProtoContract]
    [ProtoInclude(42, typeof(Intermediary))]
    public abstract class BaseClass { }
    
    [ProtoContract]
    [ProtoInclude(42, typeof(Derived))]
    public abstract class Intermediary : BaseClass { }
    
    [ProtoContract]
    public class Derived : Intermediary { }

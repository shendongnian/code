    [KnownType(typeof(X)]
    [KnownType(typeof(Y)]
    [KnownType(typeof(Z)]
    [DataContract]
    public class BaseClass
    {
        ...
    }
    [DataContract]   
    public class X : BaseClass  { ...}
    [DataContract]   
    public class Y : BaseClass  { ...}
    [DataContract]   
    public class Z : BaseClass  { ...}

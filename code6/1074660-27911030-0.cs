    public interface ISomeClass<TEnum, in S>
    {
    }
    public class SomeClass<TEnum, S> : ISomeClass<TEnum, IMyInterface>
        where TEnum : struct, IConvertible
        where S : IMyInterface
    {
    }
    public class MyContainer<TEnum> where TEnum : struct, IConvertible
    {
        public ISomeClass<TEnum, IMyInterface> MyProp { get; set; }
    }

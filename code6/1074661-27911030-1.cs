    public interface ISomeClass<TEnum>
        where TEnum: struct, IConvertible
    {
    }
    public class SomeClass<TEnum, S> : ISomeClass<TEnum>
        where TEnum : struct, IConvertible
        where S : IMyInterface
    {
    }
    public class MyContainer<TEnum> where TEnum : struct, IConvertible
    {
        public ISomeClass<TEnum> MyProp { get; set; }
    }

    private abstract class Base<T>
    {
        public T Get(IParam parameter)
        {
            return Provide(parameter);
        }
        public abstract T Provide<TParam>(TParam parameter)
            where TParam : IParam;
    }
    private class Impl : Base<string>
    {
        public override string Provide<TParam>(TParam parameter)
        {
            if (parameter is ParamImplementation1)
                return "value for implementation 1";
            if (parameter is ParamImplementation2)
                return "value for implementation 2";
            return "default value";
        }
    }

    public sealed class CommandMapper<TCommand>
    {
        public MethodMapper For<T1, T2, T3>(Expression<Action<TCommand, T1, T2, T3>> methodCall)
        {
            return CreateMethodMapper(methodCall);
        }
    }
    public sealed class MethodMapper
    {
        public void To<T1, T2, T3>(Expression<Action<T1, T2, T3>> methodCall)
        {
            // Do stuff
        }
    }

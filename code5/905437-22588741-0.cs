    public static class Visitor
    {
        public static IFuncVisitor<TBase, TResult> For<TBase, TResult>()
            where TBase : class
        {
            return new FuncVisitor<TBase, TResult>();
        }
        public static IActionVisitor<TBase> For<TBase>()
            where TBase : class
        {
            return new ActionVisitor<TBase>();
        }
        private sealed class ActionVisitor<TBase> : IActionVisitor<TBase>
            where TBase : class
        {
            private readonly Dictionary<Type, Action<TBase>> _repository =
                new Dictionary<Type, Action<TBase>>();
            public void Register<T>(Action<T> action)
                where T : TBase
            {
                _repository[typeof(T)] = x => action((T)x);
            }
            public void Visit<T>(T value)
                where T : TBase
            {
                Action<TBase> action = _repository[value.GetType()];
                action(value);
            }
        }
        private sealed class FuncVisitor<TBase, TResult> : IFuncVisitor<TBase, TResult>
            where TBase : class
        {
            private readonly Dictionary<Type, Func<TBase, TResult>> _repository =
                new Dictionary<Type, Func<TBase, TResult>>();
            public void Register<T>(Func<T, TResult> action)
                where T : TBase
            {
                _repository[typeof(T)] = x => action((T)x);
            }
            public TResult Visit<T>(T value)
                where T : TBase
            {
                Func<TBase, TResult> action = _repository[value.GetType()];
                return action(value);
            }
        }
    }
    public interface IFuncVisitor<in TBase, TResult>
        where TBase : class
    {
        void Register<T>(Func<T, TResult> action)
            where T : TBase;
        TResult Visit<T>(T value)
            where T : TBase;
    }
    public interface IActionVisitor<in TBase>
        where TBase : class
    {
        void Register<T>(Action<T> action)
            where T : TBase;
        void Visit<T>(T value)
            where T : TBase;
    }

    public static class ResolverFactory
    {
        private static Dictionary<Type, object> storage = new Dictionary<Type, object>();
        public static void RegisterResolver<TIn, TOut>(IResolver<TIn, TOut> resolver) where TIn : Stream 
        {
            storage[typeof(IResolver<TIn, TOut>)] = resolver;
        }
        public static IResolver<TIn, TOut> GetResolver<TIn, TOut>() where TIn : Stream
        {
            return storage[typeof(IResolver<TIn, TOut>)] as IResolver<TIn, TOut>;
        }
    }

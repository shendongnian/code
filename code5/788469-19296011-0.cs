    public interface IResolver<TIn, TOut>
        where TIn : Stream
    {
    }
    //Still static, but now there is one per TIn,TOut pair
    //so no need for dictionary, so also no need for casting.
    public static class ResolverFactory<TIn, TOut> where TIn : Stream
    {
        private static IResolver<TIn, TOut> _resolver;
        public static void RegisterResolver(IResolver<TIn, TOut> resolver)
        {
            _resolver = resolver;
        }
        public static IResolver<TIn, TOut> GetResolver()
        {
            return _resolver;
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            ResolverFactory<Stream, Hat>.RegisterResolver(new MyStreamToHatResolver());
            var res = ResolverFactory<Stream, Hat>.GetResolver();
        }
    }

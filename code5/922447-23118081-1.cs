    public class MyViewCache : IViewCache
    {
    ...
        public TCompiledView GetOrAdd<TCompiledView>(
            ViewLocationResult viewLocationResult, Func<ViewLocationResult, TCompiledView> valueFactory)
        {
            //if (viewLocationResult.IsStale())
            //    {
                    object old;
                    this.cache.TryRemove(viewLocationResult, out old);
            //    }
            return (TCompiledView)this.cache.GetOrAdd(viewLocationResult, x => valueFactory(x));
        }
    }

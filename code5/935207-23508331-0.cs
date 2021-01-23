    public static class IObjectExtensions
    {
        public static IEnumerable<IObject> PeformQuery<T>(
                                  this DbSet<T> set, 
                                  Func<IObject,bool> @where) 
            where T : class, IObject
        {
            return set.Where(@where).AsEnumerable();
        }
    }

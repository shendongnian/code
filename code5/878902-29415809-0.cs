    /// <summary>
    /// IDbSet extension
    /// </summary>
    public static class IDbSetExtension
    {
        public static Task<TEntity> FindAsync<TEntity>(this IDbSet<TEntity> set, params object[] keyValues) 
            where TEntity : class
        {
            return Task<TEntity>.Run(() =>
            {
                var entity = set.Find(keyValues);
                return entity;
            });
        }
    }

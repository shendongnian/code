    public static void InsertOrUpdate<T>(this Object item, Func<Object, Object> PrimaryKeyMember, DbContext Db, Func<DbContext, DbSet<T>> DbSetAttribute, bool Commit = false)
        where T : class
    {
         // ...
    }

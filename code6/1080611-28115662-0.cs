    public static IQueryable<ILocalizable<TEntity>> WithLocalization<TEntity>(this IQueryable<ILocalizable<TEntity>> query)
        where TEntity : ILocalized
      {
          return query.Include (entity => entity.Content.Select (content => content.Language));
      }
    public class Test
    {
       public Test()
       {
          IQueryable<Entity> query;
          query.WithLocalization ();
       }
    }

    public class AutofacQueryFactory<T> : IQueryFactory<T> {
         private readonly IComponentContext c;
         public AutofacQueryFactory(IComponentContext c) {
             this.c= c;
         }
         public IQuery<T> CreateQuery(string context) {
             return new Query<T>(c.ResolveNamed<IDbContext>(context));
         }
    }

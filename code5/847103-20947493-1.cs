    interface IUnitOfWork<TContext> where TContext: IDbContext { }
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : IDbContext
    {
        private readonly TContext context;
        public UnitOfWork(TContext context)
        {
            this.context = context;
        }
    }

    public class UnitOfWork<TContext>
    {
        public UnitOfWork(TContext ctx)
        {
            _ctx = ctx;
        }
    }

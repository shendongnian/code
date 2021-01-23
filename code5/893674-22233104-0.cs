    namespace USSDDomain.Core.Abstract.Contracts
    {
        public interface IPlugin
        {
            void InitializeSession<TEntity, TContext>(MBROContext context, Reporter<TEntity, TContext> reporter) where TEntity : class,IEntity where TContext : IDbContext, IDisposable, new ();
            void Execute(MBROContext context);
            string CoreCycle(MBROContext context, int stage);
            void ProcessCycle(MBROContext context, int stage, int returnStage);
            void SendResponse(MBROContext context, string xml);
            void PrepareStage(Session session);
        }
    }

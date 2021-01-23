    using System.Data.Entity.Infrastructure.Interception;
    class SequenceReadCommandInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuting(DbCommand command
               , DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }
    }

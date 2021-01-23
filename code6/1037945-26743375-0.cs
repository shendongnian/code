    internal sealed class InfrastructureDelegatingHandler : DelegatingHandler {
        private readonly IDbContext _dbContext;
        public InfrastructureDelegatingHandler(IDbContext dbContext) {
            _dbContext = dbContext;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken) {
            Task.Factory.StartNew(() => TraceRequest(request));
            return base.SendAsync(request, cancellationToken);
        }
        private void TraceRequest(HttpRequestMessage request) {
            DbRawSqlQuery<string> query = 
                ((EfDbContext)_dbContext).Database.SqlQuery<string>(
                "select name from sys.indexes");
            Console.WriteLine(String.Join(",", query.ToArray()));
        }
    }

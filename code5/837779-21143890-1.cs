    public partial class MyOwnContext : DbContext
    {
        public MyOwnContext()
        {
            var _ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
        ....
    }

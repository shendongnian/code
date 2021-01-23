    public interface Factory<T>
    {
        T Create();
    }
    public class PrincipalContextFactory : IFactory<PrincipalContext>
    {
        public PrinicipalContext Create()
        {
            // return new PrincipalContext(...);
        }
    }
    public class SqlConnectionFactory : IFactory<SqlConnection>
    {
        public SqlConnection Create()
        {
            // return new SqlConnection(...);
        }
    }

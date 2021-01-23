    public class MyRepository : IDisposable
    {
        public SqlConnection _connection = new SqlConnection("...");
    
        // [...]
        public void Dipose()
        {
            _connection.Dispose();
        }
    }

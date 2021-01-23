    public class X : IDisposable
    {
        public MySqlCommand cmdInsertThings;
        public MySqlCommand cmdInsertOtherThings;
        public bool disposed; 
        public X(MySqlConnection c)
        {
            cmdInsertThings = c.CreateCommand();
            // create parameters
            cmdInsertOtherThings = ...
        }
 
        public void PerformQuery(...)
        {
            // assign parameter values
            cmdInsertThings.ExecuteNonQuery();
        }
  
        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            cmdInsertThings.Dispose();
        }
    }

    public abstract class PaymentSystemBase : IPayable
    {
        private static string _connectionString =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString
    
        public static string ConnectionString
        {
            get { return _connection;  }
        }
    
        public abstract void ProcessPayment();
    }

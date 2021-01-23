    public static class DbInteropFactory
    {
      private static List<IFactoryWorker> _workers;
      static DbInteropFactory()
      {
          _workers = new List<IFactoryWorker>();
          _workers.Add( new SqlServerFactoryWorker() );
      }
      public static void AddWorker( IFactoryWorker worker )
      {
          _workers.Add( worker );
      }
      public static IDbInterop BuildDbInterop( 
         string ProviderName, string connectionString)
      {
         foreach ( var worker in _workers )
         {
            if ( worker.AcceptParameters( ProviderName ) )
               return worker.CreateInterop( connectionString );
            // or return null 
            throw new ArgumentException();
         }
      }

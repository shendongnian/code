    public interface IFactoryWorker : IDbInterop
    {
       IDbInterop CreateInterop( string connectionString );
       bool AcceptParameters( string ProviderName );
    }
         ...
         foreach ( var worker in _workers )
         {
            if ( worker.AcceptParameters( ProviderName ) )
               return worker;
            // or return null 
            throw new ArgumentException();
         }

    public interface IFactoryWorker
    {
       IDbInterop CreateInterop( string connectionString );
       bool AcceptParameters( string ProviderName );
    }

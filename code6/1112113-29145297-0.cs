    [Import]
        private IDbCommandInterceptor _LoggingCommandInterceptor;
    public MefConfig()
        {          
         // MEF SETUP ... ///
    System.Data.Entity.Infrastructure.Interception.DbInterception.Add(_LoggingCommandInterceptor);
        }

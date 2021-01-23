    public class ReconnectionValidator : IValidator
    {
         bool Validate (IConfiguration configuration)
         {
           return configuration.ReconnectDelay >= 60000;
         }
    }

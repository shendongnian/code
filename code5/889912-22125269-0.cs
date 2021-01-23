    public interface ILogger
    {
        bool LogMessage(string message, SeverityEnum severity..etc);
    }
    public class Service: IService
    {
         ILogger logger;
         public Service(ILogger logger)
         {
                //check if logger is not null
                this.logger = logger;
         }
    }

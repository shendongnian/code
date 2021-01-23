    public class MyProvisioningServices : ProvisioningServices
    {
         public MyProvisioningServices()
         {
             Url = ConfigurationManager.AppSettings["UbossBridgeURL"];
         }
    }

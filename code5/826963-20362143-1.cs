    namespace ProviderManger
    {
    public class ProviderManger
    {
      private ConfigHandler sendConfig;
      
      public ProviderManger()
      {
        sendConfig = ConfigurationManger.GetSection("sendProvider") as ConfigHandler;
      }
    
      public SendProviderBase GetSendProviderBase(string MapName)
      {
        try 
        {
          ProviderSettings settings = sendConfig.Providers[MapName];
          return (SendProviderBase)ProvidersHelper.InstantiateProvider(settings, typeof(SendProviderBase));
        }
        //appropriate catch block and whatever else
    }}

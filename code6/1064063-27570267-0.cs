    public class BaseTask
    {
      private string _configValue1 = "abc";
      private string _configValue2 = "def";
      private ServiceClient _serviceClient1 = new ServiceClient(configValue1,configValue2);
      Public ServiceClient ServiceClient1
       {
        get
         {
            return _serviceClient1;
         }
       set
         {
            serviceClient1 = value;
         }  
     }
    Public string ConfigValue1
     {
       get
         {
            return _configValue1;
         }
       set
         {
            _configValue1= value;
         }
     }
    Public string ConfigValue2
     {
       get
         {
            return _configValue2;
         }
       set
         {
            _configValue2 = value;
         }
     }

    public class Company
    {
    
        public string Name { get; set; }
    
    }
    
    public static class ConfigHelper
    {
    
        static ConfigHelper()
        {
            Company = new Company();
        }
    
        public static Company Company { get; private set; }
    
    }

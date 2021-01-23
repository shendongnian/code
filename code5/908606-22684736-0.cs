    void Main()
    {
        Console.WriteLine(AppOsType.IOS.Version);
        Console.WriteLine(AppOsType.IOS.ToString());
    }
    
    public class AppOsType  
    {
        // .... other members here ?? ...
        public static class IOS 
        {
            public static readnly int Version;
            static IOS()
            {
                // In the static constructor you could set the readonly
                // static property
                Version = 100;
            }
            public static string ToString() 
            {
                return "iOS";
            }
        }
    } 

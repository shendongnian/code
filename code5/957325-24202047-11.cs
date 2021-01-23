    public class CommonDbContextFactory
    {
        public static  CommonDbContext GetDbContext(string contextVersion)
        {
           switch (contextVersion)
           {
             case "A": 
                 return new DbContextA();
             case "B":
                 return new DbContextB();
             default:
                 throw new ArgumentException("Missing DbContext", "contextVersion");
           }
        }
    }

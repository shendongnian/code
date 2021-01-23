    public class Info
    {
       public string URL {get; set;}
       public string User {get; set;}
       public int Age {get; set;}
    }
    public static Info CurrentInfo()
        {
            // some code here
    
            return new Info()
            {
                URL = "www.mydomain.com",
                User = "Jack",
                Age = 20
            };
         }

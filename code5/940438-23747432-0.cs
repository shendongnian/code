    public static class Information
    {
        public static string Secret = "8675309";
    }
    public class MyViewModel 
    {
        public string Secret { get { return Information.Secret; } }
    }

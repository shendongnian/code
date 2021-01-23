    public class NotStaticClass
    {
        public static string GetString()
        {
            return "string";
        }
    }
    public static class StaticClass
    {
        public static string GetString()
        {
            return "string";
        }
    }
    // ...
    var s1 = NotStaticClass.GetString();
    var s2 = StaticClass.GetString(); // consistent across both static class and not static

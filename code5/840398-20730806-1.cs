    public class Global
    {
        public static string SomeProperty { get; private set; }
        internal static void Initialize()
        {
            // do initialize your global properties
            SomeProperty = "Something";
        }
    }

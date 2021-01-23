    public class BaseClass
    {
        public int Value { get; set; }
    }
    public static class ExtensionMethods
    {
        public static void Increment(this BaseClass b)
        {
            b.Value += 1;
        }
    }

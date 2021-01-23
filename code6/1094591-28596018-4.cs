    public static class XObjectExtensions
    {
        public static string ValueSafe(this XElement element)
        {
            return element == null ? null : element.Value;
        }
    }

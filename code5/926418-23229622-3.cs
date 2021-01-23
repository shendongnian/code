    static class XElementUtilities
    {
        public static string GetValue(this XElement xml, string name)
        {
            var element = xml.Element(name);
            return element == null ? null : element.Value;
        }
        public static bool ValueEqual(this XElement xml, string name, string value)
        {
            var element = xml.Element(name);
            return element != null && value != null && element.Value == value;
        }
    }

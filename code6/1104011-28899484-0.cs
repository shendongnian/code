    public static class XElementExtensions
    {
        public static string GetName(this XElement element)
        {
            return element.Attribute("name").Value;
        }
        public static string GetSurname(this Xelement element)
        {
            return element.Attribute("surname").Value;
        }
        // Another method for phone here
    }

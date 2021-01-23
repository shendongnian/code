    public static class EnumXmlExtensions
    {
        public static XElement EncodeXElement(this Enum @enum)
        {
            return new XElement(@enum.ToString());
        }
    }

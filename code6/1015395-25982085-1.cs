    public static class Extension
    {
        public static void SetAttributeValueEx(this XElement source, XName name, object value)
        {
            if (value == DBNull.Value) value = null;
            source.SetAttributeValue(name, value);
        }
    }

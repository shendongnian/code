     public static class ExtensionMethods
    {
        public static Guid ToGuid(this string value)
        {
            Guid result= Guid.Empty;
            Guid.TryParse(value, out result);
            return result;          
        }
    }

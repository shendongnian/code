    public static class ObjectExtensions
    {
        public static string ToStringOrNull(this object o)
        {
            return o == null ? null : o.ToString();
        }
    } 

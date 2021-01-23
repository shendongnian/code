    namespace System
    {
        public static class SystemExtensions
        {
            public static string ToConvertibleDouble(this object input)
            {
                var s = input as string;
                if (string.IsNullOrEmpty(s.Trim())) { return null; }
                // this will also take care of the separator
                return s.Replace(".", ",");
            }
        }
    }

    namespace MyProject.String.Utils
    {
        public static class String
        {
            public static string formatDecimalSeparator(this string paramString)
            {
                if (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ",")
                {
                    return paramString.Replace(".", ",");
                }
                else
                {
                    return paramString.Replace(",", ".");
                }
            }
        }
    }

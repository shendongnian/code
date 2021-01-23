    namespace MyExtensions
    {
        public static class MyStringExtensions
        {
            public static string ConvertHexToChar(this string hexData)
            {
                int c = Convert.ToInt32(hexCode, 16);
                return new string(new char[] {(char)c});
            }
        }
    }

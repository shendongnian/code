    public static class StringExtensions 
    {
        public static string CountWords(this string input )
        {
             return imnput.Split(new char[]{' '}).Length;
        }
    }

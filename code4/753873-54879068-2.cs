    static char[][] persianChars = new char[][]
        {
            "0123456789".ToCharArray(),"۰۱۲۳۴۵۶۷۸۹".ToCharArray()
        };
        static char[][] arabicChars = new char[][]
        {
            "0123456789".ToCharArray(),"٠١٢٣٤٥٦٧٨٩".ToCharArray()
        }; 
        public static string toPrevalentDigits(this string src)
        {
            if (string.IsNullOrEmpty(src)) return null;
            for (int x = 0; x <= 9; x++)
            {
                src = src.Replace(persianChars[1][x], persianChars[0][x]);
            }
            for (int x = 0; x <= 9; x++)
            {
                src = src.Replace(arabicChars[1][x], arabicChars[0][x]);
            }
            return src;
        } 

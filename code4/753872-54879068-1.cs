    static char[][] numbers = new char[][]
        {
            "0123456789".ToCharArray(),"۰۱۲۳۴۵۶۷۸۹".ToCharArray()
        };
        static char[][] arabicChar = new char[][]
        {
            "0123456789".ToCharArray(),"٠١٢٣٤٥٦٧٨٩".ToCharArray()
        }; 
        public static string toPrevalentDigits(this string src)
        {
            if (string.IsNullOrEmpty(src)) return null;
            for (int x = 0; x <= 9; x++)
            {
                src = src.Replace(numbers[1][x], numbers[0][x]);
            }
            for (int x = 0; x <= 9; x++)
            {
                src = src.Replace(arabicChar[1][x], arabicChar[0][x]);
            }
            return src;
        } 

    public static string toPrevalentDigits(this string input)
            {
                string[] persian = new string[20] { "۰", "٠", "۱", "١", "۲", "٢", "۳", "٣", "۴", "٤", "۵", "٥", "۶", "٦", "۷", "٧", "۸", "٨", "۹", "٩" }; 
                
                for (int j = 0; j < persian.Length; j++)
                    input = input.Replace(persian[j], j.ToString());
                return input;
            }

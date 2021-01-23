    public static class StringExtensionMethods
    {
        public static string ToString(this double d, int numberOfDigits)
        {
            var result = "";
            // Split the number.
            // Delimiter can vary depending on locale, should consider this and not use "."
            string[] split = d.ToString().Split(new string[] { "." }, StringSplitOptions.None);
            if(split[0].Count() >= numberOfDigits)
            {
                result = split[0].Substring(0, numberOfDigits);
            }
            else
            {
                result = split[0];
                result += ".";
                result += split[1];
                // Add padding.
                while(result.Count() < numberOfDigits +1)
                    result += "0";
                result = result.Substring(0, numberOfDigits + 1);
            }
            return result;
        }
    }

        public static char DecimalSeparator(string sValue)
        {
            var decimalPosition = sValue.Length - 4;
            if (decimalPosition < 0)
            {
                return '.';
            }
            var decimalPart = sValue.Substring(decimalPosition);
            if (decimalPart.Contains(','))
            {
                return ',';
            }
            return '.';
        }
        public static decimal StringToDecimal(string toParse)
        {
            if (string.IsNullOrEmpty(toParse))
            {
                return 0;
            }
            var stb = new StringBuilder();
            var localDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            var sourceDecimalSeparator = DecimalSeparator(toParse);
            var sNumeric = "0123456789-" + sourceDecimalSeparator;
            for (var i = 0; i < toParse.Length; i++)
            {
                var currentChar = toParse[i];
                if (sNumeric.IndexOf(currentChar) > -1)
                {
                    if (currentChar == sourceDecimalSeparator)
                    {
                        currentChar = localDecimalSeparator;
                    }
                    stb.Append(currentChar);
                }
            }
            return decimal.Parse(stb.ToString());
        }

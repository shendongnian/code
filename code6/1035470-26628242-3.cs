    static class Extensions
    {
        public static string SubstituteCurrencyString(this string input, string currencyString, string currencySymbol, bool onlyWhenPrecededByDigits = true)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (currencyString == null)
                throw new ArgumentNullException("currencyString");
            if (currencySymbol == null)
                throw new ArgumentNullException("currencySymbol");
            if (string.IsNullOrWhiteSpace(input))
                return input;
            if (!onlyWhenPrecededByDigits)
                return input.Replace(currencyString, currencySymbol);
            bool parsingNumber = false;
            StringBuilder b = new StringBuilder(input.Length);
            using (var stringEnumerator = input.GetEnumerator())
            {
                int index = -1;
                while (stringEnumerator.MoveNext())
                {
                    ++index;
                    if (char.IsDigit(stringEnumerator.Current))
                    {
                        parsingNumber = true;
                    }
                    else if (stringEnumerator.Current == CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0])
                    {
                        //Do nothing. If we are "parsing" a number, we keep on "parsing" a number. If were not, we are not.
                    }
                    else if (stringEnumerator.Current == CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator[0])
                    {
                        //Do nothing. If we are "parsing" a number, we keep on "parsing" a number. If were not, we are not.
                    }
                    else
                    {
                        if (parsingNumber && checkCurrencyString(input, currencyString, index))
                        {
                            b.Append(currencySymbol);
                            for (int i = 0; i < currencyString.Length; ++i)
                            {
                                stringEnumerator.MoveNext();
                                ++index;
                            }
                        }
                        parsingNumber = false;
                    }
                    if (index < input.Length)
                    {
                        b.Append(stringEnumerator.Current);
                    }
                }
            }
            return b.ToString();
        }
        private static bool checkCurrencyString(string input, string currencyString, int index)
        {
            Debug.Assert(input != null);
            Debug.Assert(currencyString != null);
            Debug.Assert(0 < index && index < input.Length);
            if (input.Length - index < currencyString.Length)
                return false;
            var potentialCurrenyString = input.Substring(index, currencyString.Length);
            return string.Compare(potentialCurrenyString, currencyString, false) == 0;
        }
    }

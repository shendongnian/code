    public static string ChangeNumberToEnglishNumber(string value)
        {
            string result=string.Empty;
            foreach (char ch in value)
            {
                try
                {
                    double convertedChar = char.GetNumericValue(ch);
                    if (convertedChar >= 0 && convertedChar <= 9)
                    {
                        result += convertedChar.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        result += ch;
                    }
                }
                catch (Exception e)
                {
                    result += ch;
                }
                
            }
            return result;
        }

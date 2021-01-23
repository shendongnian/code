    public bool IsDecimalLimitedtoTwoDigits(string inputvalue)
            {
                Regex isnumber = new Regex(@"^[\d]{1,6}([.]{1}[\d]{1,2})?$");
                return isnumber.IsMatch(inputvalue);
            }

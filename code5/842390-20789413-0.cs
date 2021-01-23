    public static bool ValidateDecimalString(string decimalString)
    {
        Regex regex = new Regex("^(-)?([0-9]+)(.[0-9]+)?$");
        return regex.IsMatch(decimalString);
    }

    public static bool ValidateDecimalString(string decimalString)
    {
        Regex regex = new Regex("^-?([0-9]|[1-8][0-9]|90)(.[0-9]*)?$");
        return regex.IsMatch(decimalString);
    }

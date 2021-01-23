    public static string getFormattedPrice(string value)
    {
    double moneyValue ;
    System.Globalization.CultureInfo english = new System.Globalization.CultureInfo("en-US");
    Double.TryParse(value, System.Globalization.NumberStyles.AllowDecimalPoint, english, out moneyValue);
    return moneyValue.toString();
    }

    public static string getFormattedPrice(string value)
    {
        decimal moneyValue;
        var danish = new System.Globalization.CultureInfo("da-DK");
        decimal.TryParse(value, System.Globalization.NumberStyles.AllowDecimalPoint, danish, out moneyValue);
        return moneyValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }

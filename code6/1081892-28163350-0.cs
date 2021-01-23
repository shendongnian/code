    [JsonConstructor]
    //The names of the parameters need to match those in jsonResult
    public StockQuote(string stock_name, string price)
    {
        this.stock_name = stock_name;
        //You need to explicitly tell the system it is a floating-point number
        this.price = Decimal.Parse(price, System.Globalization.NumberStyles.Float);
    }

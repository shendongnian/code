    protected string PercentageChange(object client_Price, object second_price)
    {
        if(DBNull.Value.Equals(client_Price) || client_Price == null || DBNull.Value.Equals(second_price) || second_price == null)
            return "N/A"; // or whatever
        double price1 = Convert.ToDouble(client_Price);
        double price2 = Convert.ToDouble(second_price);
        double percentagechange = ((price1 - price2) / price2) * 100;
        return percentagechange.ToString();
    } 

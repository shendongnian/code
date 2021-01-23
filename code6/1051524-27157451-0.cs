    public static Purchase GetPurchaseObject(this string csvString)
    {
        string[] parameters = csvString.Split(';');
        string productName = parameters[0];
        decimal cost = decimal.Parse(parameters[1]);
        int productCount = int.Parse(parameters[2]);
        if (parameters.Length < 4)
        {
            return new Purchase(productName, cost, productCount);
        }
        else
        {
            decimal discount = decimal.Parse(parameters[3]);
            return new DiscountPurchase(productName, cost, productCount, discount);
        }
    }

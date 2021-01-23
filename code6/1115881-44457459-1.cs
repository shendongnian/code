    public static Stock ConvertToStock(object value)
    {
        var dapperRowProperties = value as IDictionary<string, object>;
        switch (dapperRowProperties["Descriminator"])
        {
            case "Bond":
                return GetObject<Bond>(dapperRowProperties);
            case "Stock":
                return GetObject<Stock>(dapperRowProperties);
            default:
                return null;
        }
    }

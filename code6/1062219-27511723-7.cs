    public static List<SymitarAccount> GetAccounts(string accountId)
    {
        var retAccounts = new List<SymitarAccount>();
        var responses = new List<string>() { @"RSIQ~1~K0~JCLOSEDATE=00000000~JSHARECODE=1" };
        foreach (var response in responses)
        {
            var account = SomeDataFormatDeserializer.Deserlize<SymitarAccount>(response);
            retAccounts.Add(account);
        }
        return retAccounts;
    }

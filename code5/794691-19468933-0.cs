    public async static List<AccountModel> GetAccountList()
    {
        string json = await DataService.GetRequest(url);
        ...
    }

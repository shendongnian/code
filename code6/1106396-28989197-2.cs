    static void Main() {
        IClient _client;
        //_client = new ...
        var filters = new List<IFilterSetManager>() {
            new CityManager(),
            new ChainManager()
        };
        foreach (var item in filters) {
            var newFilter = item.Initialize(_client);
            //newFilter.FilterName = "City";
            //newFilter.Filters.Add(new CityBase());
        }
    }

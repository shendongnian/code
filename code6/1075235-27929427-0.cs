    public string DatabaseResult<T>(string collectionName)
        where T : IProduct
    {
        var collection = DatabaseConnect().GetCollection<T>(collectionName);
        // ...
    }

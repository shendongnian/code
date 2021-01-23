    public string CollectionJson {
        get {
            return JsonSerializer.Serialize(Collection.ToDictionary(p => p.Key.ToString(), p => p.Value));
        }
    }

    public string CollectionJson {
        get {
            // correct API as @Superstringcheese suggested
            return JsonConvert.SerializeObject(
                Collection.ToDictionary(p => p.Key.ToString(), p => p.Value));
        }
    }

    public RootObject GetApi(string url)
    {
        // ...
		return serializer.Deserialize<RootObject>(jsonReader);
	}

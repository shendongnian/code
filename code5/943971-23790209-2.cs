    void PopulateCollection()
    {
        _sharedDictionaryTask = Task.Factory.StartNew(() => GetSharedDictionary());
    }
    void ReadCollection()
    {
        DoSomethingWithCollection(_sharedDictionaryTask.Result);
    }

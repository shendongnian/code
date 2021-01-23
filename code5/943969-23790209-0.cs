    Task PopulateCollection()
    {
        return Task.Factory.StartNew(() =>
            {
                lock (_padlock)
                {
                    _sharedDictionary = GetSharedDictionary();
                }
            });
    }

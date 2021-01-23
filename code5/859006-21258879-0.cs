    private Func<MyObject, TKey> GetSortFunc<TKey>(SomeEnum sortOptions) 
    {
        switch (sortOptions)
        {
            case SomeEnum.First:
                return x => (TKey)(object)x.Id;
            case SomeEnum.Second:
                return x => (TKey)(object)x.Name;
            case SomeEnum.Third:
                return x => (TKey)(object)x.Value;
        }
    }

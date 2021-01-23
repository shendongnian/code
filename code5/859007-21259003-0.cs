    private Func<MyObject, object> GetSortFunc(SomeEnum sortOptions)
    {
        switch (sortOptions)
        {
            case SomeEnum.First:
                return x => x.Id;
            case SomeEnum.Second:
                return x => x.Name;
            case SomeEnum.Third:
                return x => x.Value;
            default:
                return x => x.Id;
        }
    }

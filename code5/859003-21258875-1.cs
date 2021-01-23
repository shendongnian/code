    private Delegate GetSortFunc(SomeEnum sortOptions)
    {
        switch (sortOptions)
        {
            case SomeEnum.First:
                return new Func<MyObject, int>(x => x.Id);
            case SomeEnum.Second:
                return new Func<MyObject, string>(x => x.Name);
            case SomeEnum.Third:
                return new Func<MyObject, int>(x => x.Value);
        }
    }
    //...
    _objects.OrderBy((dynamic)GetSortFunc(sortOptions));

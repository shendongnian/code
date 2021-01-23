    IEnumerable<MyObject> ApplySortOrder(IEnumerable<MyObject> items, SomeEnum sortOptions)
    {
        switch (sortOptions)
        {
            case SomeEnum.First:
                return items.OrderBy(x => x.Id);
            case SomeEnum.Second:
                return items.OrderBy(x => x.Name);
            case SomeEnum.Third:
                return items.OrderBy(x => x.Value);
        }
    }

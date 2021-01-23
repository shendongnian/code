    public IEnumerable<Data> SelectData(IEnumerable<Data> data, Func<Data, bool> predicate)
    {
        return data
            .Where(predicate)
            .OrderBy(GetCurrentOrderingField);
    }
    private IComparable GetCurrentOrderingField(Data x)
    {
        switch (OrderByColumn)
        {
            case "BookCategoryName":
                return x.a.BookCategoryName;
            case "BookCategoryDescription":
                return x.a.BookCategoryDescription;
        }
        return x.a.CreatedOn;
    }

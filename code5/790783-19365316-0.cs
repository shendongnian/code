    public void UpdateCollection<T, I>(T Detail, Taxes TaxesList, Func<T, I> taxSelector)
        where T : IDetail
        where I : Itaxes
    {
        I taxList = taxSelector(Detail);
        foreach (Taxes tax in TaxesList)
        {
            taxList.Add(tax);
        }
    }

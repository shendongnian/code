    public List<CustomerView> Search(Dictionary<string, string> criteria)
    {
        var x = base.DbContext.vCustomers.AsQueryable();
        foreach (var criterion in criteria)
        {
            x = x.Where(PropertyEquals<CustomerView>(
                criterion.Key, criterion.Value));
        }
        return base.Convert<List<CustomerView>>(x.ToList());
    }

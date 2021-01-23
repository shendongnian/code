    public List<CustomerView> Search(Dictionary<string, string> criteria)
    {
        var x = (from a in base.DbContext.vCustomers
                    select a);
        foreach (var criterion in criteria)
        {
            x = x.Where(PropertyEquals(criterion.Key, criterion.Value));
        }
        return base.Convert<List<CustomerView>>(x.ToList());
    }

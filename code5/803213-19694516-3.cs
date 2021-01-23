    public IEnumerable<int> GetInfo()
    {
       var query = from item in Entities.Items
                   orderby item.Id
                   select item.Id;
       return query.Cast<string>();
    }

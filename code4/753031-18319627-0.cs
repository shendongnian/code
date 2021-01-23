    public List<Item> SearchItems(string itemid, string description)
    {
        IQueryable<Item> query = _dbc.Items.Where(x => SqlMethods.Like(x.Number, itemid));
        foreach(var word in description.Split(new char[] { '%' }, StringSplitOptions.RemoveEmptyEntries)
        {
            query = query.Where(x => SqlMethods.Like(x.Description,
                                                     string.format("%{0}%", word)));
        }
        return query.ToList();
    }

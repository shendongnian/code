    public virtual IDictionary<string, T> GetCategoriesData(string serie) where T : PointBase, new()
    {
        IDictionary<string, T> categoriesData = sqlResultDataTable.AsEnumerable()
            .Where(row => row["City"].ToString() == serie)
            .Select(row => new KeyValuePair<string, T>(
                               row["Month"].ToString(),
                               new T() { X = decimal.Parse(row["Temperature"].ToString()) }))
            .ToDictionary(item => item.Key, item => item.Value);
        return categoriesData;
    }

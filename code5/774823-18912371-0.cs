    public IEnumerable<T> Fill<T>(DataTable dt)
        where T : new()
    {
        return dt.AsEnumerable().Select(row =>
        {
            var obj = new T();
            var properties = 
                from p in obj.GetType().GetProperties()
                join c in dt.Columns.Cast<DataColumn>() on p.Name equals c.ColumnName
                select new {p, c};
            foreach (var item in properties)
                item.p.SetValue(obj, row[item.c]);
            return obj;
        });
    }

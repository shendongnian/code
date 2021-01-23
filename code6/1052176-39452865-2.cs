    const string PK = "Id";
    protected Models.Entities con;
    protected System.Data.Entity.DbSet<T> model;
    private void TestUpdate(object item)
    {
        var props = item.GetType().GetProperties();
        foreach (var prop in props)
        {
            object value = prop.GetValue(item);
            if (prop.PropertyType.IsInterface && value != null)
            {
                foreach (var iItem in (System.Collections.IEnumerable)value)
                {
                    TestUpdate(iItem);
                }
            }
        }
        int id = (int)item.GetType().GetProperty(PK).GetValue(item);
        if (id == 0)
        {
            con.Entry(item).State = System.Data.Entity.EntityState.Added;
        }
        else
        {
            con.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }

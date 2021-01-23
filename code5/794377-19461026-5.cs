    var list = new List<T>();
    
    var parallelDataReader = dr.Cast<DbDataRecord>().AsParallel();
    T tObj = new T();
    
    var pinfo = tObj.GetType().GetProperties();
    
    parallelDataReader.ForAll( record =>
    {
        T obj = new T();
        foreach (PropertyInfo prop in pinfo)
        {
            var dbVal = dr[prop.Name];
            if (!Equals(dbVal, DBNull.Value))
            {
                prop.SetValue(obj, dbVal, null);
            }
        }
        list.Add(obj);
    });
    
    return list;

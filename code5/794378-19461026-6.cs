    try
    {
        List<T> list = new List<T>();
        T tObj = new T();
        var _pinfo = tObj.GetType().GetProperties();
    
        while (dr.Read())
        {
            T obj = new T();
            foreach (PropertyInfo prop in _pinfo)
            {
                var _dbVal = dr[prop.Name];
                if (!Equals(_dbVal, DBNull.Value))
                {
                    prop.SetValue(obj, _dbVal, null);
                }
            }
            list.Add(obj);
        }
        return list;
    }

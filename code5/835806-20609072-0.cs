    var obj = new ExpandoObject();
    DataSet ds = GetObjectProperties() // returns dataset having the properties as key and value pair;
    if (ds.Tables["PropTable"].Rows.Count > 0)
    {
        foreach (DataRow dr in ds.Tables["PropTable"].Rows)
        {
            string KeyName = dr["KeyName"].ToString();
            string ValueName= dr["ValueName"].ToString();
            obj[KeyName] = ValueName;
        }
    }
    dynamic DynObj = obj;
    // ...

    public object Get(FindCustomers request)
    {
        var customers = new List<Customer>();          
        var sqlAndParams = SqlAndParameters("SELECT * From Customers", request); //this returns a tuple of the sql string and the parameters
        customers = Db.Query<Customer>(sqlAndParams.Item1, sqlAndParams.Item2);
        return customers;
    }
    public virtual Tuple<String, IDictionary<string, object>> SqlAndParameters(string sql, FindCustomers request)
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate(sql);
        var sqlParams = new ExpandoObject() as IDictionary<string, object>;
        builder.Where("LastName=@LastName");
        sqlParams.Add("LastName", request.LastName);
        builder.Where("Age=@Age");
        sqlParams.Add("Age", request.Age);
        if (request.City.HasValue)
        {
            builder.Where("City=@City");
            sqlParams.Add("City", request.City);
        }
        if (request.ZipCode.HasValue)
        {
            builder.Where("ZipCode=@ZipCode");
            sqlParams.Add("ZipCode", request.ZipCode);
        }
        return Tuple.Create(selector.RawSql, sqlParams);
    }

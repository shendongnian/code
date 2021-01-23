    DataTable dt = new DataTable();
    dt.Load(cmd.ExecuteReader());
    return  (from c in dt.AsEnumerable()
             select new ProductInfo
                    {
                         id=c.Field<int>("Id"),
                         name=c.Field<string>("Name"),
                         price=c.Field<decimal>("Price")
                     }).ToList();

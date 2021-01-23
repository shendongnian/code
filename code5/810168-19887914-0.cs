    protected void test()
    {
        DataTable dt = generateData();
    
        var result = from row in dt.AsEnumerable()
                      group row by new
                      {
                          CustomerLocation = row.Field<string>("CustomerLocation"),
                      } into grp
                      select new
                      {
                          CustomerLocation = grp.Key.CustomerLocation,
                          SumSubTotal = grp.Sum(r => r.Field<int>("SubTotal")),
                          OrderCount = grp.Count(),
                          SumCustomerDebt = grp.GroupBy(r=> r.Field<int>("CustomerID"))
                                               .Sum(g => g.Average(r=> r.Field<int>("CustomerDebt"))),
                      };
    
    
        foreach (var item in result)
        {
            string info = string.Format("CustomerLocation={0},SumSubTotal={1},OrderCount={2},SumCustomerDebt={3}", item.CustomerLocation, item.SumSubTotal, item.OrderCount, item.SumCustomerDebt);
            Console.WriteLine(info);    
        }
    }

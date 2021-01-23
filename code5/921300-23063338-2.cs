    DataTable dt1 = new DataTable();
    dt1.Columns.Add("PK", typeof(int));
    dt1.Columns.Add("Data1", typeof(int));
    
    DataTable dt2 = new DataTable();
    dt2.Columns.Add("FK", typeof(int));
    dt2.Columns.Add("Data2", typeof(int));
    
    dt2.Rows.Add(1, 5000);
    dt1.Rows.Add(1, 1000);
    
    var Result = (from r1 in dt1.AsEnumerable()
                  join r2 in dt2.AsEnumerable()
                  on r1["PK"] equals r2["FK"]
                  select new
                  {
                      A = r1.Field<int>("Data1"),
                      B = r2.Field<int>("Data2"),
                      //  choose more columns if any
                  }).ToList();

    void Main()
    {
        DataTable dTable1 = new DataTable();
        DataTable dTable2 = new DataTable();
        
        dTable1.Columns.Add("id", typeof(int));
        dTable1.Columns.Add("num", typeof(int));
        dTable1.Columns.Add("value", typeof(string));
        
        dTable2.Columns.Add("id", typeof(int));
        dTable2.Columns.Add("num", typeof(int));
        dTable2.Columns.Add("name", typeof(string));
        
        dTable1.Rows.Add(new object [] { 99, 1, "+"});
        dTable1.Rows.Add(new object [] { 100, 1, "+"});
        dTable1.Rows.Add(new object [] { 101, 1, "-"});
        dTable1.Rows.Add(new object [] { 102, 1, "+"});
        
        dTable2.Rows.Add(new object [] { 99, 1, "tiger"});
        dTable2.Rows.Add(new object [] { 100, 1, "pigeon"});
        dTable2.Rows.Add(new object [] { 101, 1, "crocodile"});
        dTable2.Rows.Add(new object [] { 102, 1, "panther"});
        dTable2.Rows.Add(new object [] { 105, 1, "whale"});
        
        var vQuery = (from dt1 in dTable1.AsEnumerable()
                          join dt2 in dTable2.AsEnumerable()
                          on new { Id = dt1.Field<int?>(0), Num = dt1.Field<int?>(1) } 
                        equals new { Id = dt2.Field<int?>(0), Num = dt2.Field<int?>(1) } 
                        into temp
                        from defaultDt2 in temp.DefaultIfEmpty(null)
                  select new {
                          id = (dt1 ?? temp.First()).Field<int?>(0), 
                        num = (dt1 ?? temp.First()).Field<int?>(1), 
                        value = dt1 != null ? dt1.Field<string>(2) : null,
                        name = temp.First() != null ? temp.First().Field<string>(2) : null
                  }).Concat(
                    (from dt1 in dTable2.AsEnumerable()
                          join dt2 in dTable1.AsEnumerable()
                          on new { Id = dt1.Field<int?>(0), Num = dt1.Field<int?>(1) } 
                        equals new { Id = dt2.Field<int?>(0), Num = dt2.Field<int?>(1) } 
                                            into temp
                        from defaultDt2 in temp.ToList<DataRow>().DefaultIfEmpty(null)
                  select new 
                  {
                          id = (temp.FirstOrDefault() ?? dt1).Field<int?>(0), 
                        num = (temp.FirstOrDefault() ?? dt1).Field<int?>(1), 
                        value = temp.FirstOrDefault() != null ? temp.FirstOrDefault().Field<string>(2) : null,
                        name = dt1 != null ? dt1.Field<string>(2) : null
                  }));
        // At this point you will have the data you're after.
    }

    var result = from sqlDataRows in sqlDataTable.AsEnumerable()
      join mySqlDataRows in mySqlDataTable.AsEnumerable()
      on sqlDataRows.Field<int>("UserID") equals Convert.ToInt32(mySqlDataRows.Field<string>("SiteUserID")) into lj
      from r in lj.DefaultIfEmpty()
      select new object[] 
      {
        sqlDataRows.Field<int>("UserID"),
        sqlDataRows.Field<string>("Field1"),
        r == null ? 0 : r.Field<int>("Field2")
      };
    foreach (var item in result)
    {
      dtResult.LoadDataRow(item, false);
    }

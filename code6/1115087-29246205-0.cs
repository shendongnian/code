    var result = from sqlDataRows in sqlDataTable.AsEnumerable()
      join mySqlDataRows in mySqlDataTable.AsEnumerable()
      on sqlDataRows.Field<int>("UserID") equals Convert.ToInt32(mySqlDataRows.Field<string>("SiteUserID")) into lj
      from r in lj.DefaultIfEmpty()
      select new 
      {
        UserId = sqlDataRows.Field<int>("UserID"),
        Field1 = sqlDataRows.Field<string>("Field1"),
        Field2 = r == null ? 0 : r.Field<int>("Field2")
      };
    foreach (var item in result)
    {
      dtResult.LoadDataRow(new object[] { item.UserId, item.Field1, item.Field2 }, false);
    }

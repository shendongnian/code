    var deletedData = from c in this.DataSet.Tables["TableName1"].AsEnumerable()
                      let col1 = c.Field<string>("ColumnName1")
                      join deletedData1 in this.DataSet.Tables["TableName2"].AsEnumerable()
                      on col1 equals deletedData1.Field<string>("ColumnName2")
                      where col1 == someString
                      select new
                      {
                           T1 = c.Field<string>("ColumnName3"),
                           T2 = deletedData1.Field<string>("ColumnName4"),
                           T3 = c.Field<string>("ColumnName5"),
                           T4 = deletedData1.Field<string>("ColumnName6")
                      };

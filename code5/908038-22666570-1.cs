    var query = from r1 in table1.AsEnumerable()
                join r2 in table2.AsEnumerable()
                on new { ID = r1.Field<int>("ID"), Name = r1.Field<string>("Name") }
                equals new { ID = r2.Field<int>("ID"), Name = r2.Field<string>("Name") }
                select new { r1, r2 };
    var columnsToCompare = table1.Columns.Cast<DataColumn>().Skip(2);
    
    foreach (var rowInfo in query)
    {
        var row = table3.Rows.Add();
        row.SetField("ID", rowInfo.r1.Field<int>("ID"));
        row.SetField("Name", rowInfo.r1.Field<int>("Name"));
        foreach (DataColumn col in columnsToCompare)
        { 
            int val1 = rowInfo.r1.Field<int>(col.ColumnName);
            int val2 = rowInfo.r2.Field<int>(col.ColumnName);
            int diff = (int)Math.Abs(val1-val2);
            row.SetField(col.ColumnName, diff);
        }
    }

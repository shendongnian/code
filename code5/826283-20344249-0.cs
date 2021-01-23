    var result = from r1 in dt1.AsEnumerable()
                 join r2 in dt2.AsEnumerable()
                 on r1.Field<string>(0) equals r2.Field<string>(0)
                 select r1;
    
    var newDataTable = new DataTable();
    newDataTable.Columns.Add("MyCol", typeof(string));
    foreach (var item in result) {
        newDataTable.Rows.Add(item.ItemArray);
    }

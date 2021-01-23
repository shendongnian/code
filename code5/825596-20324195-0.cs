    DataSet ds = new DataSet();
    ds.ReadXml(filename); //or ds.ReadXml(stream)
    var tbl = ds.Tables.Cast<DataTable>().Last();
    var rows = tbl.Rows.Cast<DataRow>()
                .Select(row => row.ItemArray)
                .Select(arr => arr.Select((item, inx) => new {item,inx })
                                  .ToDictionary(y => tbl.Columns[y.inx], y => y.item))
                .ToList();

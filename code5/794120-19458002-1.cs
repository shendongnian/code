    var tuples = new List<Tuple<string, string, string, object>>();
    foreach (DataRow dr in excelExport.Rows)
    {
        int colCount = 0;
        foreach (DataColumn dc in excelExport.Columns)
        {                    
            if (colCount >= 2)
            {
                tuples.Add(Tuple.Create(dr[1],
                                        dr[2],
                                        dc.ColumnName,
                                        (object)dr[colCount])
                                       );
            }
            colCount++;
        }
    }

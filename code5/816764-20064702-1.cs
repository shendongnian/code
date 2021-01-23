    var result = dtUploadedDat.AsEnumerable()
                 .SelectMany((row,i)=>dtUploadedDat.Columns.Cast<DataColumn>()
                      .Where(col=>!strImportRequiredFields.Contains(col.ColumnName)||
                                   Convert.ToString(row[col]) == string.Empty)
                      .Select(col=>string.Format("{0},{1}",i+1,col.ColumnName)));
    //sample result
    //{"ColumnA,1", "ColumnD,5", "ColumnF,8" } 

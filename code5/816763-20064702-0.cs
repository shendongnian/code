    var result = dtUploadedDat.AsEnumerable()
                 .SelectMany(row=>dtUploadedDat.Columns.Cast<DataColumn>()
                      .Where(col=>!strImportRequiredFields.Contains(col.Name)||
                                   Convert.ToString(row[col]) == string.Empty)
                      .Select(col=>string.Format("{0},{1}",row.Index+1,col.Name)));
    //sample result
    //{"ColumnA,1", "ColumnD,5", "ColumnF,8" } 

      public static class CSVExportUtility
        {
        /// <summary>
            /// Open a datatable in Excel
            /// </summary>
            /// <param name="dt"></param>
            /// <param name="fileName"></param>
            public static void OpenAsCSV(DataTable dt, string fileName)
            {
                CSVExportUtility.OpenAsCSV(DataTableToCSV(dt), fileName); // now open the file
            }   // OpenAsCSV
        /// <summary>
            /// open the content in the browser as a CSV
            /// </summary>
            /// <param name="sbCSVFileData"></param>
            /// <param name="filename"></param>
            public static void OpenAsCSV(StringBuilder sbCSVFileData, string fileName)
            {
                if (HttpContext.Current == null || HttpContext.Current.Response == null)
                    return;
    
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader(
                    "content-disposition", string.Format("attachment; filename={0}", fileName));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
    
                // This is a little tricky.  Would like to use utf-8 or unicode... but Excel on Windows uses 1252 by default so we need to keep the same so most users can read the file.
                // At some point, we may need to actually convert our text from whatever .NET uses to 1252, but at the moment they seem similar enough that it is okay
                HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding(1252);
    
                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sbCSVFileData.ToString());
                HttpContext.Current.Response.End();
            }
    
    static StringBuilder DataTableToCSV(DataTable dt)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc == dt.Columns[dt.Columns.Count - 1])
                        CSVExportUtility.AddFieldForCSV(dc.ColumnName, sb, false, true);
                    else
                        CSVExportUtility.AddFieldForCSV(dc.ColumnName, sb, true, false);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (dc == dt.Columns[dt.Columns.Count - 1])
                            CSVExportUtility.AddFieldForCSV(FormatDataValue(dr[dc.ColumnName]), sb, false, true);
                        else
                            CSVExportUtility.AddFieldForCSV(FormatDataValue(dr[dc.ColumnName]), sb, true, false);
                    }
                }
                return sb;
            }
    
      static string FormatDataValue(object dv)
            {
                if (dv == null)
                    return null;
                if (dv is DateTime)
                    return ((DateTime)dv).ToShortDateString();
                else
                    return dv.ToString();
            }
    
            /// <summary>
            /// export text to a csv
            /// </summary>
            /// <param name="text"></param>
            /// <param name="sbCSV"></param>
            /// <param name="appendTrailingComma"></param>
            /// <param name="endOfRow"></param>
            public static void AddFieldForCSV(string text, StringBuilder sbCSV, bool appendTrailingComma, bool endOfRow)
            {
                // shouldn't start or end with whitespace, escape quotes
                if (text != null)
                    text = text.Trim().Replace("\"", "\"\"");
              
                // quote field
                int testInt;
                if (text != null && text.Trim().Length > 1 && text.Trim()[0] == '0' && int.TryParse(text.Trim(), out testInt))
                {   // if text is numeric and starts with '0' tell excel to treat as string and not strip the zero. This ONLY works if it's numeric!  Otherwise it fails, example ="a,b" will use 2 cells
                    text = "=\"" + text.Trim() + "\"";
                }
                else
                {
                    text = "\"" + text + "\"";
                }
                
                sbCSV.Append(text);
                if (appendTrailingComma)
                    sbCSV.Append(",");
                if (endOfRow)
                    sbCSV.AppendLine();
            }
    }

     public static void GenerateCSV(DataTable dt)
        {  
            StringBuilder sb = new StringBuilder();
            try
            {
                int count = 1;
                int totalColumns = dt.Columns.Count;
                foreach (DataColumn dr in dt.Columns)
                {
                    sb.Append(dr.ColumnName);
                    if (count != totalColumns)
                    {
                        sb.Append(",");
                    }
                    count++;
                }
                sb.AppendLine();
                string value = String.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    for (int x = 0; x < totalColumns; x++)
                    {
                        value = dr[x].ToString();
                        if (value.Contains(",") || value.Contains("\""))
                        {
                            value = '"' + value.Replace("\"", "\"\"") + '"';
                        }
                        sb.Append(value);
                        if (x != (totalColumns - 1))
                        {
                            sb.Append(",");
                        }
                    }
                    sb.AppendLine();
                }
            }
            catch (Exception ex)
            {
                // Do something
            }
        }

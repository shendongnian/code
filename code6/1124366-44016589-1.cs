    public static string ToCSVHighPerformance(this IDataReader dataReader, bool includeHeaderAsFirstRow = true,
                string separator = ",")
            {
                DataTable dataTable = new DataTable();
                StringBuilder csvRows = new StringBuilder();
                string row = "";
                int columns ;
                try
                {
                    dataTable.Load(dataReader);
                    columns= dataTable.Columns.Count;
                    //Create Header
                    if (includeHeaderAsFirstRow)
                    {
                        for (int index = 0; index < columns; index++)
                        {
                            row += (dataTable.Columns[index]);
                            if (index < columns - 1)
                                row += (separator);
                        }
                        row += (Environment.NewLine);
                    }
                    csvRows.Append(row);
    
                    //Create Rows
                    for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                    {
                        row = "";
                        //Row
                        for (int index = 0; index < columns - 1; index++)
                        {
                            string value = dataTable.Rows[rowIndex][index].ToString();
    
                            //If type of field is string
                            if (dataTable.Rows[rowIndex][index] is string)
                            {
                                //If double quotes are used in value, ensure each are replaced by double quotes.
                                if (value.IndexOf("\"") >= 0)
                                    value = value.Replace("\"", "\"\"");
    
                                //If separtor are is in value, ensure it is put in double quotes.
                                if (value.IndexOf(separator) >= 0)
                                    value = "\"" + value + "\"";
    
                                //If string contain new line character
                                while (value.Contains("\r"))
                                {
                                    value = value.Replace("\r", "");
                                }
                                while (value.Contains("\n"))
                                {
                                    value = value.Replace("\n", "");
                                }
                            }
                            row += value;
                            if (index < columns - 1)
                                row += separator;
                        }
                        dataTable.Rows[rowIndex][columns - 1].ToString().ToString().Replace(separator, " ");
                        row += Environment.NewLine;
                        csvRows.Append(row);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return csvRows.ToString();
            }

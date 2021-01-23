                    string table = "<table style=\"width:100%\">\n<tr>\n";
                    int columnsCount = dtData.Columns.Count;
                    foreach (DataColumn column in dtData.Columns)
                    {
                        table += "<td>" + column.ColumnName + "</td>\n";
                    }
                    table += "</tr>\n";
                    foreach (DataRow row in dtData.Rows)
                    {
                        table += "<tr>\n";
                        for (int i = 0; i < columnsCount; i++)
                        {
                            table += "<td>" + row[i] + "</td>\n";
                        }
                        table += "</tr>\n";
                    }
                    table += "</table>\n"
    
                    //use table as your messagebody into given code

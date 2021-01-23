                        StringBuilder table = new StringBuilder();                    
                        table.Append("<table style=\"width:100%\">\n<tr>\n");
                        int columnsCount = dtData.Columns.Count;
                        foreach (DataColumn column in dtData.Columns)
                        {
                            table.Append("<td>" + column.ColumnName + "</td>\n");
                        }
                        table.Append("</tr>\n");
                        foreach (DataRow row in dtData.Rows)
                        {
                            table.Append("<tr>\n");
                            for (int i = 0; i < columnsCount; i++)
                            {
                                table.Append("<td>" + row[i] + "</td>\n");
                            }
                            table.Append("</tr>\n");
                        }
                        table.Append("</table>\n");
        
                        //use table as your messagebody into given code

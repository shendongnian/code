            //create Data Row
            int count = 0;
            int rowsinserted = 0;
           
            foreach (DataRow myRow in targetTable.Rows)
            {
                htmlBuilder.AppendLine("\n<tr  align='left' valign='top'>");
                foreach (DataColumn targetColumn in targetTable.Columns)
                {
                    if (targetColumn == targetTable.Columns[0])
                    {
                        if (count == 0)
                        {
                            htmlBuilder.Append("<td rowspan='" + targetTable.Rows.Count + "' 'align='left' valign='top'>");
                            htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString());
                            htmlBuilder.Append("</td>\n");
                        }
                    }
                    else
                    
                    {
                        int columncount = 1; 
                        for (int i = 1; i < targetTable.Columns.Count; i++)
                        {
                           
                            if (targetColumn == targetTable.Columns[columncount])
                            {
                                htmlBuilder.Append("<td 'align='left' valign='top'>");
                                htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString());
                                htmlBuilder.Append("</td>\n");
                            }
                            columncount = columncount + 1;
                            count = count + 1;
                        }
                }
                }
                rowsinserted = rowsinserted + 1;
                htmlBuilder.AppendLine("</tr>\n");
            }
  

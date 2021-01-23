    //Create Data Rows
    foreach (DataRow myRow in targetTable.Rows.OrderBy(r => r[targetTable.Columns.First().ColumnName].ToString()))
    {
        htmlBuilder.AppendLine("\n<tr align='left' valign='top'>");
        foreach (DataColumn targetColumn in targetTable.Columns)
        {
            // if its the first column then only add a cell when its the first time 
            // value appears, else just add the cell
            if(targetColumn == targetTable.Columns.First())
            {
                // if its the first time the value has appeared in the first column
                // then add cell with rowspan set to the number of appearances
                if(myRow == targetTable.Rows.OrderBy(r => r[targetTable.Columns.First().ColumnName].ToString()).First(r => r[targetColumn.ColumnName].ToString() == myRow[targetColumn.ColumnName].ToString()))
                {
                    rowspan = targetTable.Rows.Count(r => r[targetColumn.ColumnName].ToString() == myRow[targetColumn.ColumnName].ToString());
                                        
                    htmlBuilder.Append("<td  rowspan='"+rowspan+"' align='left' valign='top'>");
                    htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString());
                    htmlBuilder.Append("</td>\n");
                }
            }
            else
            {              
                htmlBuilder.Append("<td  align='left' valign='top'>");
                htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString());
                htmlBuilder.Append("</td>\n");
            }
        }
        htmlBuilder.AppendLine("</tr>\n");
    }

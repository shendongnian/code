    bool background=false;
    foreach (DataColumn column in dsDashboardDetails.Tables[0].Columns)
                    {
                        html.Append("<td>");
    if (background) { // add color }
    background = !background;
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }

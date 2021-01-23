    StringBuilder html = new StringBuilder();
    var rowCount = 0;
    foreach (DataRow row in dsDashboardDetails.Tables[0].Rows)
    {
        var className = rowCount++ % 2 == 0 ? "even" : "odd"; //check if it is an odd or even rowCount
        html.Append("<tr style='color: Black' class='"+className+"'>");
        foreach (DataColumn column in dsDashboardDetails.Tables[0].Columns)
        {
            html.Append("<td>");
            html.Append(row[column.ColumnName]);
            html.Append("</td>");
        }
        html.Append("</tr>");
    }
    //Table end.
    html.Append("</table>");

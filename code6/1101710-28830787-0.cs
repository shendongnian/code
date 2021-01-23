    StringBuilder html = new StringBuilder();
    var rowIndex = 0;
    foreach (DataRow row in dsDashboardDetails.Tables[0].Rows) {
        html.AppendFormat("<tr style='color: {0}'>", 
            rowIndex % 2 == 0 ? "Black" : "Red"); // Red or anything you want
        foreach (DataColumn column in dsDashboardDetails.Tables[0].Columns) {
            html.Append("<td>");
            html.Append(row[column.ColumnName]);
            html.Append("</td>");
        }
        html.Append("</tr>");
    }
    //Table end.
    html.Append("</table>");

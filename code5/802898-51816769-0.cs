    Public Shared Function ConvertDataTableToHTML(dt As DataTable) As String
        Dim html As String = "<table>"
        html += "<tr>"
        For i As Integer = 0 To dt.Columns.Count - 1
            html += "<td>" + System.Web.HttpUtility.HtmlEncode(dt.Columns(i).ColumnName) + "</td>"
        Next
        html += "</tr>"
        For i As Integer = 0 To dt.Rows.Count - 1
            html += "<tr>"
            For j As Integer = 0 To dt.Columns.Count - 1
                html += "<td>" + System.Web.HttpUtility.HtmlEncode(dt.Rows(i)(j).ToString()) + "</td>"
            Next
            html += "</tr>"
        Next
        html += "</table>"
        Return html
    End Function

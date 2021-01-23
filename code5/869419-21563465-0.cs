    My.Response.ContentType = "application/json"
    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
    Dim dt As DataTable = GetDataTable("proc_name", My.Request.QueryString("term"))
    Dim orgArray As ArrayList = New ArrayList
    For Each row As DataRow In dt.Rows
    	Dim thisorg As New thisOrg
            thisorg.id = row("organization_child_id")
            thisorg.value = row("organization_name")
            orgArray.Add(thisorg)
    Next
    My.Response.Write(serializer.Serialize(orgArray))
    Public Class thisOrg
        Public id As Integer
        Public value As String
    End Class

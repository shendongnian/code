    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) 'Handles RadGrid1.NeedDataSource
        Dim RadGrid1 As RadGrid = CType(Page.FindControl("RadGrid1"), RadGrid)
        RadGrid1.DataSource = GetDataTable("SELECT کالا.شناسه, کالا.عنوان, کالا.پوشه, بارگیری, کالا.گروه_شناسه, گروه.عنوان AS گروه FROM کالا LEFT JOIN گروه ON کالا.گروه_شناسه = گروه.شناسه")
    End Sub
    Public Function GetDataTable(ByVal query As String) As DataTable
        Dim ConnString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim conn As SqlConnection = New SqlConnection(ConnString)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        adapter.SelectCommand = New SqlCommand(query, conn)
        Dim table1 As New DataTable
        conn.Open()
        Try
            adapter.Fill(table1)
        Finally
            conn.Close()
        End Try
        Return table1
    End Function

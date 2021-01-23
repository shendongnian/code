    Private Shared Function IsValidExcelWorksheetName(ByVal m_connexcel As OleDbConnection, _
                                                      ByVal Filepath As String, _
                                                      ByVal SheetName As String) As Boolean
        Try
            Dim ExcelSheets As DataTable = m_connexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            For Each Row As DataRow In ExcelSheets.Rows
                If Row.Item("TABLE_NAME") = SheetName Then Return True
            Next
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Shared Function GetFirstExcelWorksheetName(ByVal m_connexcel As OleDbConnection, ByVal Filepath As String) As String
        Try
            Dim ExcelSheets As DataTable = m_connexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            Return ExcelSheets.Rows(0).Item("TABLE_NAME")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

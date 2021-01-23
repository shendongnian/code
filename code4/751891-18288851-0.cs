    Public Class ExcelReader
        Public Event DataTableLoaded(ByVal dt As DataTable)
        .......
    
            Using cn = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.12.0;.......")
            Using cmd = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", cn)
                cn.Open()
                cmd.Fill(DT)
                RaiseEvent DataTableLoaded(DT)
            End Using
            End Using
        ....
    End Class

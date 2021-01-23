    Public Function GetObjects(ByVal lines As String()) As DataTable
       Dim cmd As OracleCommand
       Dim par As OracleParameter
       Dim da As OracleDataAdapter, dt As New DataTable
       
       cmd = New OracleCommand("BEGIN :res := Myfunction(:lines); END;", server.con)
       cmd.CommandType = CommandType.Text
       
       ' Return value
       cmd.Parameters.Add("res", OracleDbType.RefCursor, ParameterDirection.ReturnValue)
       
       par = cmd.Parameters.Add("lines", OracleDbType.Varchar2, ParameterDirection.Input)
       par.CollectionType = OracleCollectionType.PLSQLAssociativeArray
       par.Value = lines
       par.Size = lines.Length
       cmd.ExecuteNonQuery()
    
       da = New OracleDataAdapter(cmd)
       da.Fill(dt)
       Return dt
    
    End Function

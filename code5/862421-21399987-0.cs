    Public Sub DynamicDML()
       Dim cmd As OracleCommand
       Dim par As OracleParameter
       Dim DML As New List(Of String), dmlArray As String()
    
       DML.Add("DELETE FROM TABLE_A")
       DML.Add"INSERT INTO TABLE_B VALUES (...)")
       DML.Add("UPDATE TABLE_C SET ...")
       dmlArray = DML.ToArray
    
       cmd = New OracleCommand("BEGIN MyProcedure(:lines); END;", server.con)
       cmd.CommandType = CommandType.Text
    
       par = cmd.Parameters.Add("lines", OracleDbType.Varchar2, ParameterDirection.Input)
       par.CollectionType = OracleCollectionType.PLSQLAssociativeArray
       par.Value = dmlArray 
       par.Size = dmlArray.Length
       cmd.ExecuteNonQuery()
    
    End Sub

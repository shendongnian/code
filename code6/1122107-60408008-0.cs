     Public Shared Function AssignStringToCLOB(ByVal targetString As String, ByVal myConnection As OracleConnection) As OracleLob
        Dim _tempCommand As New OracleCommand()
        _tempCommand.Connection = myConnection
        _tempCommand.Transaction = _tempCommand.Connection.BeginTransaction()
        _tempCommand.CommandText = "DECLARE A " + OracleType.Clob.ToString() + "; " + "BEGIN " + "DBMS_LOB.CREATETEMPORARY(A, FALSE); " + ":LOC := A; " + "END;"
        Dim p As OracleParameter = _tempCommand.Parameters.Add("LOC", OracleType.Clob)
        p.Direction = ParameterDirection.Output
        _tempCommand.ExecuteNonQuery()
        Dim _tempCLOB As OracleLob = CType(p.Value, OracleLob)
        If targetString <> String.Empty Then
            Dim _bytesArray As Byte() = Text.Encoding.Unicode.GetBytes(targetString)
            _tempCLOB.BeginBatch(OracleLobOpenMode.ReadWrite)
            _tempCLOB.Write(_bytesArray, 0, _bytesArray.Length)
            _tempCLOB.EndBatch()
        End If
        _tempCommand.Transaction.Commit()
        Return _tempCLOB
    End Function

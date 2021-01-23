        Private Sub LongRunningProcess()
        Dim _conn As New SqlClient.SqlConnection("Data Source=.\sqlexpress;Initial Catalog=MARS_ProcTest;Integrated Security=True;MultipleActiveResultSets=True;")
        Dim cmd As New SqlClient.SqlCommand("exec StoredProcedure1", _conn)
        Dim ds As New DataSet
        _conn.Open()
        cmd.ExecuteNonQuery()
        _conn.Close()
    End Sub

    Private Sub StatusChecker()
        Dim _conn As New SqlClient.SqlConnection("Data Source=.\sqlexpress;Initial Catalog=MARS_ProcTest;Integrated Security=True;MultipleActiveResultSets=True;")
        Dim cmd As New SqlClient.SqlCommand("select status from Table1", _conn)
        Dim ds As New DataSet
        _conn.Open()
        While Not _done
            Dim stat As String
            stat = cmd.ExecuteScalar()
            If Me.InvokeRequired() Then
                Me.Invoke(Sub()
                              Me.Label1.Text = stat
                          End Sub)
            Else
                Me.Label1.Text = stat
            End If
        End While
        _conn.Close()
    End Sub

    Private Sub OnInfoMessage(sender As Object, args As SqlClient.SqlInfoMessageEventArgs)
        For Each sqlEvent As System.Data.SqlClient.SqlError In args.Errors
            Dim msg As String = String.Format("Msg {0}, Level {1}, State {2}, Line {3}{4}", sqlEvent.Number, sqlEvent.Class, sqlEvent.State, sqlEvent.LineNumber, Environment.NewLine)
            'Write msg to output
        Next
    End Sub
    Private Sub OnStatementCompleted(sender As Object, args As StatementCompletedEventArgs)
        Dim msg As String = String.Format("({0} row(s) affected)", args.RecordCount)
        'Write msg to output
    End Sub
    Public Sub Work()
        Using dbc As New SqlConnection(Me.ConnectionString),
              dbcmd As New SqlCommand()
            dbcmd.Connection = dbc
            dbcmd.CommandTimeout = Convert.ToInt32(timeout) ' you will want to set this otherwise it will timeout after 30 seconds
            'set other dbcmd properties
            
            AddHandler dbc.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
            AddHandler dbcmd.StatementCompleted, AddressOf OnStatementCompleted
            
            dbc.Open()
            
            'dbcmd.ExecuteNonQuery() or Using dataReader As SqlDataReader = dbcmd.ExecuteReader()
            
        End Using
    End Sub

    Private Async Sub updateUI()
        Dim sw As New Stopwatch
        While True
            Await Task.Delay(3000)
            sw.Restart()
            Dim dt as myDataSet.myDataTable = getDataWithMySQL("SELECT ... LEFT JOIN ...")
            UpdateDGV(dt)
            'myTableAdapter.Fill(myDataSet.myTable)
            logger.Debug(sw.ElapsedMilliseconds)
        End While
    End Sub
    
    ' You need to change `DataGridView` here to be the actual datagridview control on the form
    Private Sub UpdateDGV(newSource as myDataSet.myDataTable)
        DataGridView.SuspendLayout()
        DataGridView.DataSource = Nothing
        DataGridView.DataSource = newSource 
        DataDridView.ResumeLayout()
    End Sub
    
    ' Make the function easier to reuse by passing in the SQL command
    Private Function getDataWithMySQL(sqlCmd as string) As myDataSet.myDataTable
        Dim connStr As String = My.Settings.myConnectionString
        Dim dt As New myDataSet.myDataTable
        Using conn As New MySqlConnection(connStr)
            Using cmd As New MySqlCommand()
                With cmd
                    .CommandText = sqlCmd
                    .Connection = conn
                End With
                Try
                    conn.Open()
                    Dim sqladapter As New MySqlDataAdapter(cmd)
                    sqladapter.Fill(dt)
                Catch ex As MySqlException
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return dt
    End Function

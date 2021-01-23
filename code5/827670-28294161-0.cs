    Private Sub CreateDatabase()
        Using c As DataContext = New DataContext(DataContext.ConnectionString)
            c.CreateIfNotExists()
            c.LogDebug = True
        End Using
    End Sub

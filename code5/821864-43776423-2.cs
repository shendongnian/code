    Dim newConnectionString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=DB;Persist Security Info=True;User ID=sa;Password=pass"
    Using ctx As New DlmsDataContext(newConnectionString)
        ' ...
        ctx.SaveChanges()
    End Using

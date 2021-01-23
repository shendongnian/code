            Dim dt As New DateTime
            Dim txtDateFromUser As String = "04/09/2014"
            If DateTime.TryParse(txtDateFromUser, dt) = True Then
                Dim connStr As String
                connStr = System.Configuration.ConfigurationManager.ConnectionStrings("youConnectionStringName").ConnectionString
                'Insert into database
                Dim sqlconn As New SqlConnection
                sqlconn.ConnectionString = connStr
                Dim sqlcmd As New SqlCommand("insert into tblDateTime (dtTestDate) values ('" + dt.ToString() + "')")
                sqlconn.Open()
                sqlcmd.Connection = sqlconn
                sqlcmd.ExecuteNonQuery()
            End If

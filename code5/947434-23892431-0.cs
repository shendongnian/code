    Dim objConnection As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("Connection").ConnectionString)
    Dim objSelectCommand As New SqlCommand("SQL statement if you desire it", objConnection)
    Dim objDataReader As SqlDataReader = Nothing
    objConnection.Open()
    objDataReader = objSelectCommand.ExecuteReader

    SqlCommand d = new SqlCommand("select Name from OCRMonitor where OCRServer = @server", ProdrefConn);
    d.Parameters.Add("Server", SqlDbType.VarChar, 50).Value = server.ToString();
    SqlDataReader reader = d.ExecuteReader();
    reader.Read();
    
    txtName.Text = reader.GetString(0);
    reader.Close();
    
    ProdrefConn.Close();

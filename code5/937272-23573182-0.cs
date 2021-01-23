    ProdrefConn.Open();
    
    if (cbServer.SelectedIndex == 0)
    {
        server = "Adtukfocr01";
        if (rbNuix.Checked == true)
        {
            Query("nuixAssigned");
        }
        else if (rbLeverage.Checked == true)
        {
            Query("leverageAssigned");
        }
    }
  
    private void Query (string TableName)
        {
         SqlCommand d = new SqlCommand("select"+TableName+" from OCRMonitor where OCRServer = @server", ProdrefConn);
        
        d.Parameters.Add("@Server", SqlDbType.VarChar, 50).Value = server.ToString();
        
        SqlDataReader reader = d.ExecuteReader();
        using (reader)
        {
          while(reader.Read())
         {
          txtName.Text = reader[0].ToString();
         }
        }
        
        
        ProdrefConn.Close();
        }
        }

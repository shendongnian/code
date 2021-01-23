    SqlConnection conn = new SqlConnection("your connection");
    SqlCommand cmnd = new SqlCommand();
    SqlDataReader sdr = null;
    conn.Open();
    cmnd.Connection = conn;
    String qury = "Select ID from Seller ORDER BY ID";                
    cmnd.CommandText = qury;
    sdr = cmnd.ExecuteReader();
    
    while (sdr.Read())
    {
       comboID.Items.Add(sdr.GetString(0));
    }

    string connString = "Data Source=localhost;Integrated " +   "Security=SSPI;Initial Catalog=Northwind;";
    
    using (SqlConnection conn = new SqlConnection(connString))
    {
      SqlCommand cmd = new;
      cmd.CommandText = "SELECT ID, Name FROM Customers";
      
      conn.Open();
    
      using (SqlDataReader rd = command.ExecuteReader())
        {
            rd.Read();
            string pass = rd["Sifre"].ToString();
            int p = Convert.ToInt32(pass);
    
            return p;
        }
    }

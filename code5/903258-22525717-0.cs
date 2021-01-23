    public string opt() {
      using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["nmrbg"].ConnectionString)) {
        conn.Open();
    
        using (SqlCommand cmd = new SqlCommand("nmp_sp_sy", conn)) {
          cmd.CommandType = CommandType.StoredProcedure;
    
          using (SqlDataReader rdr = cmd.ExecuteReader()) {
            if (!rdr.Read())
              return "0000";
    
            Object rawData = rdr.GetValue(0);
    
            if (Object.RefrenceEquals(null, rawData))  
              return "0000"; // <- Or whatever on null value
            else
              return rawData.ToString();    
          }
        }
      }
    }

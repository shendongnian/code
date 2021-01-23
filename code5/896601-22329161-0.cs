    using (SqlConnection sc = new SqlConnection(connString))
       {
          SqlCommand sCmd = new SqlCommand("select some from tbl", sc);
          sc.Open();
          SqlDataReader sdr = sCmd.ExecuteReader();
          sdr.Close();
       }

    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
    {
     SqlCommand cmd = new SqlCommand("select Top 1 Total from tablename order by total desc", con);
     SqlDataReader rdr;
     con.Open();
     rdr = cmd.ExecuteReader();
     while (rdr.Read())
      {
       int total;
       int.TryParse(rdr["Total"].ToString(), out total);
      }
    
    }

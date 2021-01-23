    public static List<Personen> GetAllPersonWithID(int id)
    {
        List<Personen> lstPersonen = new List<Personen>();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["RestaurantConnection"].ConnectionString;
        string sql = "SELECT * FROM Personen where reservering_id=@id";
        
        using(SqlConnection con = new SqlConnection(constring))
        {             
           con.Open();
           using(SqlCommand cmd = new SqlCommand(sql, con))
           {
              cmd.Parameters.AddWithValue("@id", id);
              using(SqlDataReader rdr = cmd.ExecuteReader())
              {
                 while (rdr.Read())
                 {
                     Personen Item = new Personen();
                     Item.id = Convert.ToInt32(rdr["id"]);
                     Item.menu_id = Convert.ToInt32(rdr["menu_id"]);
                     Item.reservering_id = Convert.ToInt32(rdr["reservering_id"]);
                     lstPersonen.Add(Item);
                 }
              }
           }
        }
        return lstPersonen;
    }

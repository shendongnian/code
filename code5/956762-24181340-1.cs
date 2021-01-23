    public static List<Personen> GetAllPersonWithID(int id)
    {
        var lstPersonen = new List<Personen>();
        using(SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RestaurantConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Personen where reservering_id=" + id, con);
            con.Open();
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
        return lstPersonen;
    }

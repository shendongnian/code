        public static List<Personen> GetAllPersonWithID(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString =   System.Configuration.ConfigurationManager.ConnectionStrings["RestaurantConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Personen where reservering_id=" + id, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Personen> rtnList = new List<Personen>();
            while (rdr.Read())
            {
                Personen personen = new Personen();
                personen.id = Convert.ToInt32(rdr["id"]);
                personen.menu_id = Convert.ToInt32(rdr["menu_id"]);
                personen.reservering_id = Convert.ToInt32(rdr["reservering_id"]);
                rtnList.Add(personen);
            }
            con.Close();
            return rtnList;
        }

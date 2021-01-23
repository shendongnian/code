    public static class AbonnementsId
    {
        public static int GetAbonnementsId()
        {
            int abonnementsid;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            using(var conn = new SqlConnection(connectionString))
            {
                int brugerid = Convert.ToInt32(HttpContext.Current.Session["id"]);
                        
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = @"SELECT abonnementsid from brugere WHERE id = @id";
                cmd1.Parameters.AddWithValue("@id", brugerid);
                conn.Open();
            
                SqlDataReader readerBrugerA = cmd1.ExecuteReader();
                if (readerBrugerA.Read())
                    abonnementsid = Convert.ToInt32(readerBrugerA["abonnementsid"]);
                conn.Close();
            }
            return abonnementsid;
        }
    }

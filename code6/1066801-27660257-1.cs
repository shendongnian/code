    using(SqlConnection pripojeni  = new SqlConnection(connectionstring))
        {
            pripojeni.Open();
            SqlCommand prikaz = new SqlCommand();
            prikaz.Connection = pripojeni;
            prikaz.CommandText = " SELECT COUNT (*) FROM HlavniTab";
            int pocet = (int)prikaz.ExecuteScalar();
            pripojeni.Close();
            return pocet;
        }

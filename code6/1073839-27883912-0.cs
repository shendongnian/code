    using (SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
    {
        sqlCon.Open();
         foreach (var row in d.Rows)
        {
            using (SqlCommand sqlCmd1 = new SqlCommand { CommandText = "INSERT INTO [GooData] ([gasource], [gamedium], [gacampaign], [gatransactionid], [gadate], [gatotalvalue]) VALUES (@gasource, @gamedium, @gacampaign, @gatransactionid, @gadate, @gatotalvalue)", Connection = sqlCon })
             {
                        sqlCmd1.Parameters.AddWithValue("@gasource", row[0]);
                        sqlCmd1.Parameters.AddWithValue("@gamedium", row[1]);
                        sqlCmd1.Parameters.AddWithValue("@gacampaign", row[2]);
                        sqlCmd1.Parameters.AddWithValue("@gatransactionid", row[3]);
                        sqlCmd1.Parameters.AddWithValue("@gadate", row[4]);
                        sqlCmd1.Parameters.AddWithValue("@gatotalvalue", row[5]);     
                        sqlCmd1.ExecuteNonQuery();
             }
           
        }
        sqlCon.Close();
    }

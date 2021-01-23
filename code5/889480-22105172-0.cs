    try
    {
        using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM datas", connection))
            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                        switch (dr["namen"].ToString())
                        {
                            case "gt": Label2.Text = dr["dest"].ToString(); break;
                            case "gp1": Image1.ImageUrl = dr["dest"].ToString(); break;
                            case "gp2": Image2.ImageUrl = dr["dest"].ToString(); break;
                            case "gp3": Image3.ImageUrl = dr["dest"].ToString(); break;
                        }
                }
                dr.Close();
            }
            connection.Close();
        }
    }
    catch (Exception ex)
    {
        Response.Write("An error occured: " + ex.Message);
    }

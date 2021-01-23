    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                //open connection with database
                connection.Open();
                //query to select all users with the given username
                command.CommandText = "select * from artikulli ";
                List<object> users = new List<object>();
                using (SqlDataReader rd = command.ExecuteReader())
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            users.Add(rd[0].ToString());
                        }
                    }
                }
                myGridView.DataSource = users;
                myGridView.DataBind();
            }
        }
    }

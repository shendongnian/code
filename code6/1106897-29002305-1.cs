        private void BindData()
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionstring.ToString()))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Table", connection))
                {
                    adapter.Fill(ds);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionstring.ToString()))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) AS 'Count' FROM Table", connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dictionaryIds.Add(Convert.ToInt32(reader["Id"].ToString()), Convert.ToInt32(reader["Count"].ToString()));
                    }
                    connection.Close();
                }
            }
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }

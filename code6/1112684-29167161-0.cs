        try
        {
            using (SqlConnection conn = new SqlConnection(@"..."))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"select Name from Org", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox1.Text = reader["Name"].ToString();
                        }
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
        }

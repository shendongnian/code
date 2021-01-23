    using (SqlConnection conn = new SqlConnection("your connection string"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM users", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds;
            }

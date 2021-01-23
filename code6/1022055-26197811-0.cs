       SqlConnection cn = new SqlConnection("my connection string");
        cn.Open();
        string sql = "select * from table where column = whatever";
        using (SqlCommand cmd = new SqlCommand(sql,cn))
        {
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                myTextBox1.Text = (string)dr["Column1"];
                myTextBox2.Text = (string)dr["Column2"];
                myTextBox3.Text = (string)dr["Column3"];
            }
            dr.Close();
        }
        cn.Close();

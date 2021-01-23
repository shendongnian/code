    using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=db_WiBo;Integrated Security=True"))
    {
       using (SqlCommand cmd = new SqlCommand(@"SELECT * from tb_Account where Username= '@username'  AND Password= '@password' ", conn))
       {
          cmd.Parameters.Add("@username", textBox1.Text);
          cmd.Parameters.Add("@password", textBox2.Text);
          conn.Open();
          SqlDataReader reader = cmd.ExecuteReader();
          if (reader.HasRows)
          {
             reader.Close();
             this.Hide();
          }
          conn.Close();
       }
    }

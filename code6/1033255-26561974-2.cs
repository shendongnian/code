    using(SqlConnection con = new SqlConnection(.......))
    using(SqlCommand cmd = new SqlCommand("select id from qw where name=@name", con))
    {
        con.Open();
        cmd.Parameters.AddWithValue("@name", TextBox1.Text);
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
           if(dr.read())
           {
               TextBox2.Text = dr[0].ToString();
           }
        }
    }

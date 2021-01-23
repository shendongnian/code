    using(SqlConnection con = new SqlConnection(CnnStr))
    using(SqlCommand cmd = con.CreateCommand())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SearchSp";
        cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = TextBox4.Text.Trim();
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
           GridView1.DataSource = dr;
           GridView1.DataBind();
        }
    }

    using(var con = new SqlConnection(...))
    {
        var cmd = new SqlCommand("select * from Table1 where ID = @ID", con);
        con.Open();
        cmd.Parameters.AddWithValue("@ID", LbLID.Text.Trim());
        var da = new SqlDataAdapter(cmd);
        var dt = new DataTable();
        da.Fill(dt);
        lblS1.Text = dt.Rows[0][4].ToString();
        lblS1.DataBind();
    }

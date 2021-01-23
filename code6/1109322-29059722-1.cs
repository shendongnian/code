    protected void Button1_Click(object sender, EventArgs e)
    {
        string cmdText = @"INSERT INTO dbo.Movie  (MovieName) values(@name)";
        using(SqlConnection con = new SqlConnection(.......constringhere...))
        using(SqlCommand cmd = new SqlCommand(cmdText, con))
        { 
            con.Open();
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtmovie.Text;
            cmd.ExecuteNonQuery();
            ....
        }
    }

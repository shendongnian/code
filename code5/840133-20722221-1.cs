    UName = TextBox1.Text;
    CompN = TextBox2.Text;
    TMin = TextBox3.Text;
    Name = TextBox4.Text;
    TextBox1.Visible = false;
    TextBox2.Visible = false;
    TextBox3.Visible = false;
    TextBox4.Visible = false;
    string sql = "INSERT INTO table_name values ('" + Name + "','" + UName + "','" + CompN + "','" + TMin + "','NA', 0 )";
    conn.Open();
    try
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }
    catch
    {
        Response.Write( "<script>alert( 'SQL error: try again later' )</script>" );
    }
    finally
    {
        conn.Close();
    }

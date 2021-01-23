    String connString = @"Data Source (LocalDB)\v11.0;AttachDbFilename=C:\Users\Spyer\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
    String sql = "Select Count(*) From Login where Username = @Name and Password = @Password";
    Int32 ccount;
    using (SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
        cmd.Parameters["@Name"].Value = textBox1.Text;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar);
        cmd.Parameters["@Password"].Value = textBox2.Text;
        try
        {
            conn.Open();
            ccount = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    using (SqlConnection conn = new SqlConnection(yourconnectionstring))
    {
        string sql = "Select description from vul_auto where finding_id=@id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = s1;
        try
        {
            conn.Open();
            TextBox3.Text = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //Handle exception
        }
    }

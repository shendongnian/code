    using (SqlConnection conn = ConnectionClass.GetInstance().Connection())
    using (SqlCommand cmd = new SqlCommand(TextBoxQuery.Text, conn))
    {
        conn.Open();
        TextBoxNoOfRowEffected.Text = cmd.ExecuteNonQuery().ToString();
    }

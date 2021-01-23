    using (SqlConnection con = new SqlConnection(WF_AbsPres.Properties.Settings.Default.DbConnectionString))
    {
       con.Open();
       SqlCommand command2 = new SqlCommand("DELETE FROM DevInOut where Cardserial=@Cardserial", con);
       commdand2.Parameters.AddWithValue("@Cardserial", textBox5.Text);
       command2.ExecuteNonQuery();
       con.Close();
    }

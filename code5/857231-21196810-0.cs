    string query = "insert into Feedback ([From],Message) values(@frm,@msg)";
    using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString))
    {
      SqlCommand comm = new SqlCommand(query, con);
      comm.Parameters.AddWithValue("@frm", Convert.ToInt32(TextBoxid.Text));
      comm.Parameters.AddWithValue("@msg",TextBoxFeedBack.text);
      con.Open();
      comm.ExecuteNonQuery();
      con.Close();
    }

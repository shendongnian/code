    SqlConnection con = new SqlConnection("Your connection");
    con.Open();
    SqlCommand cmd = new SqlCommand("Select * from Trial where FirstColumn = '"+RadTextBox1.Text+"'",con);
    SQlDataReader dr = cmd.ExecuteReader();
    while(dr.Read())
    {
      if(dr.HasRows())
      {
         RadTextBox2.Text = dr.GetString(1);
         RadTextBox3.Text = dr.GetString(2);  
      }
      else
      {
            //Simply Leave it
      }
    }
    con.Close();

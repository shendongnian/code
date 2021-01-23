    try
    { 
       con.Open();
       SqlDataReader myReader = null;
    
       SqlCommand cmd = new SqlCommand("select sum(amount) from income where date = @date", con);
       cmd.Parameters.AddWithValue("@date", TextBox15.Text);
    
       myReader = cmd.ExecuteReader();
    
       if (myReader.Read())
       {
           TextBox16.Text =myReader[0].ToString();
       }
    
       con.Close();
    
    }
    catch (Exception e1)
    {
       Label1.Text = e1.Message;
    }

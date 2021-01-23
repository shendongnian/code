    try
        {
            con.Open();
    
            SqlDataReader myReader = null;
    
            SqlCommand cmd = new SqlCommand("select sum(amount) as totalamount from income where date=@datevalue", con);
            cmd.Parameters.Add(new SqlParameter("@datevalue", TextBox15.Text));
            myReader = cmd.ExecuteReader();
    
            while (myReader.Read())
            {
                TextBox16.Text = (myReader["totalamount"].ToString());
            } 
            con.Close();
    
        }
        catch (Exception e1)
        {
            Label1.Text = e1.Message;
        }
       
       

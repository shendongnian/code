    SqlConnection con=new Sqlconnenction("Your Connection String");
    con.Open();
    Sqlcommand cmd = new SqlCommand("Select * from your database",con); // Your two columns
    SqlDateReader dr=cmd.ExecuteReader();
    while(dr.Read())
    {
      if(dr.GetString(1) == "decimal") // dr.GetString(1) = 'Your Second Column'
      {
        TextBox1.Text = dr.GetString(0);
      }
      else if(dr.GetString(1)=="int")
      {
        Label1.Text = dr.GetString(0);
      }
      else if(dr.GetString(1)=="varchar")
      {
        Button1.Text = dr.GetString(0);
      }
    }
    con.Close();

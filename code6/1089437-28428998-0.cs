    while(dr.Read())
     {
        if (dr.HasRows)
       {
         Label2.Text = dr["password"].ToString();
       }
      else
       {
         Label2.Text = "try again";
       }
     }

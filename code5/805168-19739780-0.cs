        bool flagset=false;
        
        using (SqlConnection con = new SqlConnection(cn.ConnectionString))
        {
         using (SqlCommand cmd = new SqlCommand())
           {
            cmd.CommandText = "select password from TestDemo where userName=@uName";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@uName", txtusername.Text); 
            cmd.Connection = con;
            con.Open();
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             if (dr.HasRows){
               while (dr.Read())
                {
                    if(da[0].ToString()==txtusername.Text)
                     {     flagset=true;   }
                }
                }dr.Close();
                 con.Close();
          }
    }return flagset;

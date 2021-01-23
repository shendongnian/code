     SqlConnection con = new SqlConnection(@"Data Source=WIN-218NC1F1FE2\SQLEXPRESS;Initial Catalog=projet;Integrated Security=True");
        con.Open();
        SqlCommand cmd = new SqlCommand("select max(id_reservation) from reservation");
        cmd.Connection = con;
        Int32 maxId = (Int32)cmd.ExecuteScalar();  
         string ID=maxId.TOString();
        //correct 
    
     /////INSERT  
        SqlCommand q = new SqlCommand("insert into reservation(location) values(@location,@ID)", con);
              q.Parameters.AddWithValue( "@location",OUI);
              q.Parameters.AddWithValue("@ID",ID);
              q.ExecuteNonQuery(); 
              return true ;
    ////////UPDATE
    
         SqlCommand q = new SqlCommand("update  reservation set location=@location where id_reservation =@ID", con);
                  q.Parameters.AddWithValue( "@location",OUI);
                  q.Parameters.AddWithValue("@ID",ID);
                  q.ExecuteNonQuery(); 
                   return true ;

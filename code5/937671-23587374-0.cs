    using (SqlConnection con = new SqlConnection(constr))
    {
        con.Open();
        using (SqlCommand scm = new SqlCommand())
        {
            scm.Connection = con;
            scm.CommandText = @"select [BOOk_ID],[Member_id] from [borrow] where 
                                BOOk_ID=@bkid AND Member_id =@mbid";
            scm.Parameters.AddWithValue("@bkid", textBox19.Text);
            scm.Parameters.AddWithValue("@mbid", textBox18.Text);
            using(SqlDataReader reader = scm.ExecuteReader())
            {
                if(reader.HasRows())
                {
                   reader.Read();
                   using (SqlCommand scm2 = new SqlCommand())
                   {
                       scm2.Connection = con;
                       scm2.CommandText = @"delete from Borrow where
                                          BOOk_ID=@bkid AND Member_id =@mbid";
                       scm2.Parameters.AddWithValue("@bkid", textBox19.Text);
                       scm2.Parameters.AddWithValue("@mbid", textBox18.Text);
                       scm2.ExecuteNonQuery();
                   }
               }
            }
        }
    }

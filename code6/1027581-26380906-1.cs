            SqlConnection con=new SqlConnection("your Connection string here");
            SqlCommand cmd=new SqlCommand("your SQL Query here",con);
            using(SqlDataReader rdr = cmd.ExecuteReader())
            {
              if(rdr.HasRows)
              {
                while (rdr.Read())
                {
                    string myString = rdr.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                    (or)
                     string myString= rdr["ColumnName"].ToString();
                }
        }
    
    }

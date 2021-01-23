         _command = new SqlCommand(query, _connection);
                da.SelectCommand = _command ;
                DataSet ds = new DataSet();
                da.Fill(ds);
              if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    //write your code
     		return true;
                    }
                }

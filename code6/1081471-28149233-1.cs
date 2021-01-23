    public long GetUserId(string username)
        {
            using (var con = new SqlConnection(cs))
            {
                var da =
                    new SqlDataAdapter("Select UserId from Users where UserName=username", con);
                DataSet ds = new DataSet();
                da.Fill(ds);                
                return (long)ds.Tables[0].Rows[1].ItemArray[1];
            }            
        }

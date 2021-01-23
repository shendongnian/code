    public long GetUserId(string username)
        {
            using (var con = new SqlConnection(cs))
            {
                var da =
                    new SqlDataAdapter("Select UserId from Users where UserName=username", con);
                return (long)da;
            }            
        }

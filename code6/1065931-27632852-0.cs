    public bool ValidRegLogUser()
             {
                bool _UserValid = false;
    
                    using(var conn = new SqlConnection())
                    {
                        string querystring = "Select * from users where UserName=@userName and userPassword=@userPassword";
                        SqlCommand command = new SqlCommand(querystring,conn);
                        command.Parameters.Add("@userName", SqlDbType.VarChar).Value =      UserName;
                        command.Parameters.Add("@userPassword", SqlDbType.VarChar).Value =      Password;
    
                        conn.Open();
    
                        using (SqlDataReader conReader = command.ExecuteReader())
                        {
                            if (conReader.Read() == true)
                            {
                                UserName = Convert.ToString(conReader["userName"]);
                                LogType = Convert.ToString(conReader["userPrivileges"]);
                                _UserValid = true;
                            }
                        }
                    }
    
                return _UserValid;
             }

    UserInfo info = new UserInfo();
    if (reader.Read())
            {
                
                    info.role = reader.GetString(0);
                    info.fullName = reader.GetString(1);
                    info.email = reader.GetString(2);
                
                sqlCon.Close();
                
            }
            else
            {
                info.ErrorCode =  "An error has occurred";
            }
      return info;

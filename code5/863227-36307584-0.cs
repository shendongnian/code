    for(int i=0;i<usersList.Count;i++)
            {
                if (!(selectedUsersArray[i].Equals("")) && !passwordArray[i].Equals(""))
                {
                    cmd.Parameters.clear();//Add this line
                    OracleParameter userName = new OracleParameter();
                    userName.ParameterName = "user";
                    userName.Value = selectedUsersArray[i];
    
                    OracleParameter passwd = new OracleParameter();
                    passwd.ParameterName = "password";
                    passwd.Value = passwordArray[i];
    
                    cmd.Parameters.Add(userName);
                    cmd.Parameters.Add(passwd);
    
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();                   
    
    
                }
            } 

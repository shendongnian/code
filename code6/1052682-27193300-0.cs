    public const string InsertStmtUsersTable = "insert into userinfo (UserName, FirstName, LastName, 
                          [E-mail], Password,  Country) values (@UserName, @FirstName, @LastName, 
                          @[E-mail], @Password,  @Country) "
        using(SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
        
            SqlCommand command = new SqlCommand(InsertStmtUsersTable, conn);
            command.CommandType = CommandType.Text;
        
            command.Parameters.Add(new SqlParameter("username", userNameString));
            command.Parameters.Add(new SqlParameter("FirstName", FirstNameString));
            // Rest of your Parameters here
        
            
            command.ExecuteNonQuery();
        }

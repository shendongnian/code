    try
    {
           using(sqlCommand = new SqlCommand("GetUserByUserIdPassword2", sqlConnection, sqlTransaction))
           {
                  sqlCommand.CommandTimeout = 15;
                  sqlCommand.CommandType = CommandType.StoredProcedure;
                  SqlParameter parameterUserId = sqlCommand.Parameters.Add("@UserId", SqlDbType.NVarChar, 32);
                  parameterUserId.Value = userId;
                  SqlParameter parameterPassword = sqlCommand.Parameters.Add("@Password", SqlDbType.NChar, 64);
                  parameterPassword.Value = this.GetSHA256Hash(password);
        
                  sqlCommand.Disposed += new System.EventHandler(this.sqlCommand_Disposed);
        
                  SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);
                  // exception thrown, no sored proc "GetUserByUserIdPassword2"
                  sqlDataReader.Close();
           }
    }
    catch(...) {}
    
    ...
    
    private void sqlCommand_Disposed(object sender, EventArgs e)
    {
         MessageBox.Show("sqlCommand has been disposed");
    }

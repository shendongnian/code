    private void Method2()
    {
        string sEmail = "test@test.com";
        string passwordHash = "#$@#$@!#@$$@#!#@$!#@$!";
        string salt = "????";
        string sName = "John";
        using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            try
            {
                sqlConnection.Open();
                string insertStatement = "INSERT INTO [User] "
                                            + "(email, hash, salt, name) "
                                            + "VALUES (@email, @hash, @salt, @name)"
                                            + "SET @user_id = SCOPE_IDENTITY()";
                using (SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection))
                {
                    insertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = sEmail;
                    insertCommand.Parameters.Add("@hash", SqlDbType.VarChar, 50).Value = passwordHash;
                    insertCommand.Parameters.Add("@salt", SqlDbType.VarChar, 50).Value = salt;
                    insertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = sName;
                    insertCommand.Parameters.Add("@user_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();
                    int userId = Convert.ToInt32(insertCommand.Parameters["@user_id"].Value);
                    Trace.WriteLine("User created with id: " + userId);
                }
            }
            catch (SqlException ex)
            {
                Trace.WriteLine(ex.Message);
                //lblMessage.Text = ex.Message;
            }
    }

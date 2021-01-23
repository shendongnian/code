    protected void registerBtn_Click(object sender, EventArgs e)
    {
        String conString = "....";
        string cmd = @"INSERT INTO Student( First_Name, Surname, User_ID, Password) 
                       VALUES (@first, @surname, @id, @password);"
        using(SqlConnection myConnection = new SqlConnection(conString))
        using(SqlCommand myCommand = new SqlCommand(cmd, myConnection))
        {
            myCommand.Parameters.Add(new SqlCommand() 
            {
               ParameterName = "@first",
               Value= fNameTxt.Text, 
               SqlDbType = SqlDbType.NVarChar,
               Size = 50
            });
            myCommand.Parameters.Add(new SqlParameter
            {
                 ParameterName = "@surname",
                 Value= sNameTxt.Text, 
                 SqlDbType = SqlDbType.NVarChar,
                 Size = 50
            });
            myCommand.Parameters.Add(new SqlParameter() 
            {
                 ParameterName = "@id",
                 Value= Convert.ToInt32(userIdTxt.Text), 
                 SqlDbType = SqlDbType.Int
            });
            myCommand.Parameters.Add(new SqlParameter() 
            {
                 ParameterName = "@password",
                 Value= passwordTxt.Text, 
                 SqlDbType = SqlDbType.NVarChar,
                 Size = 16
            });
    
            myCommand.Connection = myConnection;
            myConnection.Open();
            if(myCommand.ExecuteNonQuery() > 0)
                Label1.Text = "You have successfully registered";
        }
    }

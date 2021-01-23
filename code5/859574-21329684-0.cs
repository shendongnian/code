    if(txtRegisterSecurityAnswerOne.TextLength >0 && txtRegisterSecurityAnswerTwo.TextLength >0)
    {
        SqlConnection connection1 = new SqlConnection(Properties.Settings.Default.BlackBookDBConnectionString);
        connection1.Open();
        string sqlquery = "INSERT INTO [User] (Username,Password,SecurityQuestionOne,"
            + "SecurityAnswerOne,SecurityQuestionTwo,SecurityAnswerTwo) "
            + "VALUES (@Username,@Password,@QuestionOne,@AnswerOne,@QuestionTwo,@AnswerTwo)";
       
        SqlCommand command = new SqlCommand(sqlquery, connection1);
    
        string userName = txtRegisterUsername.Text;
        command.Parameters.Add("@Username", SqlDbType.VarChar, 200).Value = userName;
        string password = txtRegisterRepeatPassword.Text;
        command.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = password;
        string questionOne = lstRegisterSecurityQuestionOne.SelectedText;
        command.Parameters.Add("@QuestionOne", SqlDbType.VarChar, 200).Value = questionOne;
        string questionTwo = lstRegisterSecurityQuestionTwo.SelectedText;
        command.Parameters.Add("@QuestionTwo", SqlDbType.VarChar, 200).Value = questionTwo;
        string answerOne = txtRegisterSecurityAnswerOne.SelectedText;
        command.Parameters.Add("@AnswerOne", SqlDbType.VarChar, 200).Value = answerOne;
        string answerTwo = txtRegisterSecurityAnswerTwo.SelectedText;
        command.Parameters.Add("@AnswerTwo", SqlDbType.VarChar, 200).Value = answerTwo;
    
        command.ExecuteNonQuery();
        connection1.Close();
    }

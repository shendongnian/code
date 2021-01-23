     [WebMethod]
    public string GetUserQuestion(string email)
    {
        try
        {
            //Connect to database.
            this.ConnectToDatabase();
            OleDbCommand cmd = conn.CreateCommand();
            //The query to return the value of the index of the question that is stored in the arraylist.
            cmd.CommandText = "SELECT SecurityInfo.QuestionNumber FROM [SecurityInfo] INNER JOIN [UserDetails] ON SecurityInfo.ID = UserDetails.ID WHERE (((UserDetails.Email) = '" + email + "'));";
            
            OleDbDataReader reader = cmd.ExecuteReader();
            //Only needs to be read once since only one row will always be returned.
            reader.Read();
            int questionNumber = (int)reader["QuestionNumber"];
            
            //Get the question from the array.
            string Question = (string)questionArray[questionNumber];
          
            return Question;
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            this.DisconnectDatabase();
        }
    }

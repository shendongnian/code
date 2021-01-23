    private int GetQuestionIds(string content, int quizId)
    {
        List<int> idQuestions = new List<int>();
        string query
            = "SELECT ID FROM Questions WHERE (content = @content AND Quiz_ID = @quizId)";
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@content", content);
            command.Parameters.AddWithValue("@quizId", quizId);
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int idQuestion = Convert.ToInt32(Global.reader.GetValue(0));
                        idQuestions.Add(idQuestion);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return idQuestions.Any() ? idQuestions.First() : -1;
    }

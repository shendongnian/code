    List<QuestionAnswer> listOfQuestionsAndAnswers = new List<QuestionAnswer>();
    using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["2012SSMS"].ConnectionString))
    {
        SqlCommand cmd1 = new SqlCommand(@"SELECT [Question], [Answer] 
                                           from [MyTable]", conn1);
        conn1.Open();
        using (SqlDataReader reader1 = cmd1.ExecuteReader())
        {
               while(reader1.Read())
               {
                   QuestionAnswer qa = new QuestionAnswer();
                   qa.Question = reader1.GetString(0); 
                   qa.Answer = reader1.GetString(1); 
                   listOfQuestionsAndAnswers.Add(qa);
               }
        }
    }

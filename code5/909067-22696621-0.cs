    List<string> qustions = new List<string>();
    foreach(var id in questionId)
    {
               Query = "SELECT *  FROM QuestionsTable WHERE Id = '" + id + "'";
               theReader = conn.ExecuteStatement(Query);
               while(theReader.Read())
               {
                  question = theReader["Question"].ToString();
                  qustions.add(question);
               }
    
    }

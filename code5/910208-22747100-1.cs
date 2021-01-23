    string registerquery = "Insert into surveyresponses  (ANSWER) values (@ans)";
    
    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SurveyUserdataConnectionString2"].ConnectionString))
    {
     using (SqlCommand comm = new SqlCommand(registerquery, conn))
     {
      comm.Parameters.AddWithValue("@ans", answer);
      comm.ExecuteNonQuery();
     }
    }
 

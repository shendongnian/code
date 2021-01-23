    List<sp_GetAllQuestionsResult> QuestionList= Session["QuestionsList"] as List<sp_GetAllQuestionsResult>;
    // Check if the list is null or not
    if(QuestionList != null)
    {
        // Safe to use list because it was found and successfully cast
    }

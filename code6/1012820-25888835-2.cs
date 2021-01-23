    [HttpPost]
    public ActionResult Create(ExamVM model)
    {
      foreach(QuestionVM q in model.Questions)
      {
        if (q.IsSelected)
        {
          // Save the value of exam.ID and question ID to the database
    

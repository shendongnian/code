    [HttpPost]
    public ActionResult YourMethod(MyVM model)
    {
      if(model.SelectedAnswer.HasValue)
      {
        // property SelectedAnswer contains the ID of the selected answer (from radio button)
      }
      else
      {
        foreach(AnswerVM answer in model.Answers)
        {
          if (answer.IsSelected)
          {
            // answer.ID contains the ID of the checked answers (from checkboxes)

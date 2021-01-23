    upd.ForEach(_obj => 
     {
        if (question.AssignedTo == null)
        {
            question.QuestionStatusId = 6;
        }
        else
        {
            question.AssignedDate = DateTime.UtcNow;
            question.QuestionStatusId = 5;
        }
        _uow.Questions.Update(_obj);
      }
    );

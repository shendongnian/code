    for (int a = 0; 0 < int.Parse(number); a++)
    {
        Question o = new Question
        {
            QuizID = int.Parse(id)
        };
        db.Questions.InsertOnSubmit(o);
        db.SubmitChanges();
    }

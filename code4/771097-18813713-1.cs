    public QuestionDetail GetQuestionDetail(int questionId)
    {
        var questions = _questionsRepository
            .GetAll()
            .Include(q => q.Answers)
            .Take(1)   // Constrain to one result fetched from DB
            .ToArray() // Invoke query in DB
            .Select(m => new QuestionDetail
            {
                QuestionId = m.QuestionId,
                Text = m.Text.FormatCode()
            })
            .FirstOrDefault();
        return questions;
    }

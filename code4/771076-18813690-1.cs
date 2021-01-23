    QuestionDetail questions = _questionsRepository
            .GetAll()
            .Include(q => q.Answers)
            .Take(1)
            .ToList()
            .Select(m => new QuestionDetail
            {
                QuestionId = m.QuestionId,
                Text = m.Text,
                Answers = m.Answers.Select(a => 
                                  new AnswerDetail { AnswerId = a.AnswerId, 
                                                     Text = a.Text }).ToList()
            });

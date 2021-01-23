    QuestionDetail questions = _questionsRepository
                .GetAll()
                .Include(q => q.Answers)
                .Select(m => new QuestionDetail
                {
                    QuestionId = m.QuestionId,
                    Text = m.Text,
                    Answers = m.Answers.Where(x=>yourCondition)
                })
                .FirstOrDefault();

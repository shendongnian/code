    var questionTmp = _questionsRepository
            .GetAll()
            //.Include(q => q.Answers) // commented out since you aren't selecting this
            .Select(m => new // Anonymous type
            {
                QuestionId = m.QuestionId,
                Text = m.Text, // raw data to be used as input for in-memory processing
            })
            .FirstOrDefault(); // or use .ToList(); if you want multiple results

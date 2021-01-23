    var questions = result1
        .GroupBy(
        r => new { r.Id, r.Text, r.Result },
        (key, results) => new QuestionDTO 
        {
            Id = key.Id,
            Text = key.Text,
            Answers = results
            .Select(r => new AnswerDTO 
            { 
                AnswerId = r.AnswerId, 
                AnswerText = r.AnswerText,
                AnswerResult = key.Result 
            })
            .ToList()
         }
      )
      .ToList();

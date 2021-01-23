    var questions = result1
      .GroupBy(
        r => new { r.Id, r.Text },
        (key, results) => new Question {
          Id = key.Id,
          Text = key.Text,
          Answers = results
            .Select(r => new Answer { AnswerId = r.AnswerId, AnswerText = r.AnswerText })
            .ToList()
        }
      )
      .ToList();

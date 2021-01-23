    var userQuizzes = from quiz in Context.Quizzes
                  select new DashboardQuiz
                  {
                      QuizId = quiz.Id,
                      Questions = quiz.Questions
                      QuestionExcerpt =     quiz.QuizVersion.Questions.FirstOrDefault().QuestionText
                      // I'd like to call IsQuizActive() here
                  }
    var newUserQuizzes = userQuizzes.ToList().Select(x => {
        x.ActiveQuiz = x.IsQuizActive();
        return x;
    });

    return View(new StudentViewModel
    {
        GeneralQuestions =
            new List<Question>
            {
                new Question
                {
                    QuestionString = "Q1",
                    PossibleAnswers =
                        new[]
                        {
                            new PossibleAnswer {Id = 1, Answer = "A01"},
                            new PossibleAnswer {Id = 2, Answer = "A02"}
                        }
                },
                new Question
                {
                    QuestionString = "Q2",
                    PossibleAnswers =
                        new[]
                        {
                            new PossibleAnswer {Id = 11, Answer = "A11"},
                            new PossibleAnswer {Id = 12, Answer = "A12"}
                        }
                },
            }
    });

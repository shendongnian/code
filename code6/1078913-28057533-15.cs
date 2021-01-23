    StudentVM model = new StudentVM();
    model.ID = 1;
    model.Name = "bambiinela";
    model.Subjects = new List<SubjectVM>()
    {
      new SubjectVM()
      {
        Questions = new List<QuestionVM>()
        {
          new QuestionVM()
          {
            ID = 1,
            Text = "Question 1",
            SelectedAnswer = ?, // set this if you want to preselect an option
            PossibleAnswers = new List<AnswerVM>()
            {
              new AnswerVM()
              {
                ID = 1,
                Text = "Answer A"
              },
              new AnswerVM()
              {
                ID = 1,
                Text = "Answer B"
              }
            }
          },
          new QuestionVM()
          {
            ID = 2,
            Text = "Question 2",
            PossibleAnswers = new List<AnswerVM>()
            {
              // similar to above
            }
          }
        }
      },
      new SubjectVM()
      {
        ID = 1,
        Name = "Math",
        Questions = new List<QuestionVM>()
        {
          // similar to above
        }
      }
    };

    public ActionResult CreateQuestions()
    {
        RegistrationViewModel vm = new RegistrationViewModel();
        .....
        // Populate the questions and answers
        var questions = facade.GetQuestions().ToList();
        var answers = facade.GetPossibleAnswers();
        foreach (var question in questions)
        {
          QuestionVM qvm = new QuestionVM();
          qvm.ID = question.ID;
          qvm.Test = question.Text;
          // Add possible answers for the question
          qvm.PossibleAnswers = answers.Where(a => a.QuestionID ==  question.ID);
          // If loading existing questions/answers for existing user, also set value of current SelectedAnswer so its selected by default in the view
          vm.Questions.Add(qvm);
        }
        return View(vm);
    }

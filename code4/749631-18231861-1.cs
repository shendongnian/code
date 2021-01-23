    using (var wizardStepService = new WizardStepService(exam1))
    {
        var question = wizardStepService.GetNextQuestion();
        //Should output question1
        Console.WriteLine(question.Content);
        Console.ReadLine();
        //Should output question2 but outputs question1
        question = wizardStepService.GetNextQuestion();
        Console.WriteLine(question.Content);
        Console.ReadLine();
        //Should output question3 but outputs question1
        question = wizardStepService.GetNextQuestion();
        Console.WriteLine(question.Content);
        Console.ReadLine();
    }

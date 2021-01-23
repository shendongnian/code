    foreach (QuestionUnit questionUnit in myQuestions)
    {
        Console.WriteLine(questionUnit.Question);
        foreach (string answer in questionUnit.Answers)
        {
            Console.WriteLine(answer);
        }
        Console.WriteLine("Make a selection, A - D");
        Console.ReadLine();
    }

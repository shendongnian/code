    using (var questions = exam1.Questions.GetEnumerator())
    {
        questions.MoveNext();
        var question = questions.Current;
        //Should output question1
        Console.WriteLine(question.Content);
        Console.ReadLine();
        //Should output question2 but outputs question1
        questions.MoveNext();
        question = questions.Current;
        Console.WriteLine(question.Content);
        Console.ReadLine();
        //Should output question3 but outputs question1
        questions.MoveNext();
        question = questions.Current;
        Console.WriteLine(question.Content);
        Console.ReadLine();
    }

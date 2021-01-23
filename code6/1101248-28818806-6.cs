    public static void Main()
    {
        const int numberOfQuestions = 3;
        const int sumOfDifficulty = 15;
        // Since I don't have your table, I'm using a list of objects to fake it
        var questions = new List<Question>();
        for (int i = 1; i < 11; i++)
        {
            questions.Add(new Question {Difficulty = i % 10, 
                QuestionString = "Question #" + i});
        }
        var results = GetQuestions(questions, numberOfQuestions, sumOfDifficulty);
        // Write output to console to verify results
        foreach (var result in results)
        {
            Console.WriteLine("{0} = {1}", string.Join(" + ", 
                result.Select(r => r.Difficulty)), sumOfDifficulty);
        }
    }

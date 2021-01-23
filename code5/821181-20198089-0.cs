    public static void RandomiseAnswers(IEnumerable<Question> questions)
    {
        var rand = new Random((int)DateTime.Now.Ticks);
        foreach (var question in questions) 
        {
            question.Answers = question.Answers.OrderBy(x => rand.Next()).ToArray();
        }
    }

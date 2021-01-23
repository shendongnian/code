    public static void main()
    {
        var random = new Random();
        var questions = new List<string>{
            "question1",
            "question2",
            "question3"};
        int index = random.Next(questions.Count);
        Console.WriteLine(questions[index]);
    }

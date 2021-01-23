    public static void main()
    {
        var questions = new List<string>{
            "question1",
            "question2",
            "question3"};
        Random rnd = new Random();
        int index = rnd.Next(questions.Count)
        string question  = questions[index];
        questions.RemoveAt(index); // Are you sure you neex to remove?
        System.Console.WriteLine(question);
    }

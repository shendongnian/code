    class Questions
    {
        public static void main()
        {
            var questions = new List<string>{
                "question1",
                "question2",
                "question3"};
            int index = Random.Next(questions.Count);
            System.Console.WriteLine(questions[index]);
    
        }
    }

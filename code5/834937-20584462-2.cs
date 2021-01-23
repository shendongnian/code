    class Program
    {
        static void Main(string[] args)
        {
            var quest = File.ReadLines("l1.txt").Select(ProcessLine).ToArray();
            var rnd = new Random();            
            int questionNum = rnd.Next(0, quest.Length - 1);
            Question question = quest[questionNum];
            Console.WriteLine(quest[questionNum].What);
            // Get the user input
            //if(question.CheckAnswer(userAnswer))
            //    Console.WriteLine("Win");
            //else
            //    Console.WriteLine("Try again");
        }
        private static Question ProcessLine(string s)
        {
            var tokens = s.Split('|');
            if (tokens.Length <= 2)
                throw new ArgumentException("Invalid question");
            return new Question()
            {
                What = tokens[0],
                Answers = tokens.Skip(1).Take(tokens.Length - 2).ToArray(),
                Correct = tokens[tokens.Length - 1]
            };
        }
    }

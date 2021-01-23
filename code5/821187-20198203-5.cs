        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("text.txt");
            List<AskQuestion> Questions = new List<AskQuestion>();
            Random rnd = new Random(DateTime.Now.Millisecond);
            while(!sr.EndOfStream)
            {
                AskQuestion NewQuestion = new AskQuestion();
                string[] input = sr.ReadLine().Split(';');
                NewQuestion.Question = input[0];
                NewQuestion.Explanation = input[5];
                for(int i = 1; i < 5; i++)
                {
                    Answer NewAnswer = new Answer();
                    NewAnswer.Value = input[i];
                    NewQuestion.Answers.Add(NewAnswer);
                }
                NewQuestion.Answers[0].Correct = true;
                NewQuestion.Answers = NewQuestion.Answers.OrderBy(x => rnd.Next()).ToList();
                Questions.Add(NewQuestion);
            }
            foreach(AskQuestion q in Questions)
            {
                Console.WriteLine(q.Question + ":\n\tA - " + q.Answers[0].Value + "\n\tB - " + q.Answers[1].Value + "\n\tC - " + q.Answers[2].Value + "\n\tD - " + q.Answers[3].Value + "\n");
                char input = '0';
                while(input < 'A' || input > 'D')
                {
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if(input >= 'A' && input <= 'D')
                    {
                        if(q.Answers[input - 'A'].Correct)
                        {
                            Console.WriteLine("\nCorrect\n");
                        }
                        else
                            Console.WriteLine("\nWrong\n");
                        Console.WriteLine(q.Explanation);
                    }
                }
            }
            Console.ReadLine();
        }

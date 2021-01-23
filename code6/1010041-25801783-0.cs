    static void Main(string[] args)
    {
    
          Console.WriteLine("Please enter the question:");
          string question = Console.ReadLine();
          File.AppendAllText("question.txt", question);
          File.AppendAllText("question.txt", "\n");
          Console.WriteLine("Please enter the term to solve");
          string term = Console.ReadLine();
          File.AppendAllText("question.txt", term + Environment.NewLine);
    }

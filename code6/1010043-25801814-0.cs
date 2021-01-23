      Console.WriteLine("Please enter the question:");
      string question = Console.ReadLine();
      
      Console.WriteLine("Please enter the term to solve");
      question += Environment.NewLine + Console.ReadLine();
      File.WriteAllText("question.txt", question );

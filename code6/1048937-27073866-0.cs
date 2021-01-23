    List<int> scores = new List<int>();
    Console.WriteLine("Input all of your test scores as the program prompts of");
    Console.WriteLine("each score on the lines below. (i.e. 89 25 87 98...)");
    string line;
    Console.WriteLine("\nEnter test score #1");
    while ((line = Console.ReadLine()) != "")
    {
        scores.Add(int.Parse(line));
        Console.WriteLine("\nEnter test score #{0}", scores.Count + 1);
    }
    PrintScores(scores.ToArray());

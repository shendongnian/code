    public bool MatchesMyCondition(string line) {...}
    public void DoSomething(string line) {...}
    System.IO.StreamReader file = new System.IO.StreamReader("myFile.txt");
    while((line = file.ReadLine()) != null && MatchesMyCondition(line))
    {
       DoSomething(line);
    }
    file.Close();

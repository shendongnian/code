    public static void Main()
    {
        Console.Clear();
        string file = @FILEPATH
        string grades = File.ReadAllText(file);                                                                                  
        int acount = grades.Count(c => c == 'A');
        Graph.Grapher(acount);// this is the change
    }

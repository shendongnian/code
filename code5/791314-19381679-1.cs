    static List<string> list = new List<string> { "A", "B", "C", "D", "E" }; 
    static List<string> finished = new List<string>(); 
    public static void Main()
    {
        for (int i = 0; i < list.Count - 1; i++)
            for (int j = i+1; j < list.Count; j++)
                finished.Add(list[i]+","+list[j]);
    }

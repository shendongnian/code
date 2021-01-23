    static void Main(string[] args)
    {
    
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
    
        foreach (var i in list)
            Console.WriteLine(i);
    
    
        //Shuffle the list
        var shuffled = Shuffle<int>(list);
    
        foreach (var i in list)
            Console.WriteLine(i);
        Console.Read();
    }
    public static List<T> Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }

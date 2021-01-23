    static void Main()
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
          
        Console.WriteLine("please enter key and value");
        int key = int.Parse(Console.ReadLine());
        int val = int.Parse(Console.ReadLine());
        if (!dic.ContainsValue(val))
            dic.Add(key, val);
    }

    int num;
    var nums = new List<int>();
    
    while (nums.Count < 10)
    {
        Console.Write("Enter: ");
        if (int.TryParse(Console.ReadLine(), out num))
        {
            nums.Add(num);
            Console.Clear();
        }
    }
    
    Console.WriteLine(string.Join(", ", nums));

    List<int> numbers = new List<int>();
    int line;
    do
    {
        line = Console.Read();
        if (line != -1)
            numbers.Add(line);
    } while (line != -1);
    for(int x = 0; x < numbers.Count(); x++)
       Console.WriteLine(numbers[x]);

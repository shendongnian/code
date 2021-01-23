    List<int> numbers = new List<int>();
    string line;
    do
    {
        line = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(line))
        {
            int number;
            if(int.TryParse(line, out number))
                numbers.Add(number);
        }
        
    } while (!string.IsNullOrWhiteSpace(line));
    for(int x = 0; x < numbers.Count(); x++)
       Console.WriteLine(numbers[x]);

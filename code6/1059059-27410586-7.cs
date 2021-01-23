    List<int> numbers = new List<int>();
    string line = Console.ReadLine();
    int number;
    do
    {
        if(int.TryParse(line, out number))
            numbers.Add(number);
    } while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()));
    for(int x = 0; x < numbers.Count(); x++)
       Console.WriteLine(numbers[x]);

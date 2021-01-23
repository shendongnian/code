    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputNumber;
        while (int.TryParse(Console.ReadLine(), out inputNumber))
        {
            numbers.Add(inputNumber);
        }
    }

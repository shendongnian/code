    static void Main(string[] args)
    {
      List<int> numbers = new List<int>() { 4, 2, 1, 3, 5, 10, 50, 4003, 2, 6};
      int count = numbers.Count;
      for (int j = count; j >= 0; j--)
      {
        int i = 0;
        for (i = 0; i <= j - 2; i++)
        {
          if (numbers[i] < numbers[i + 1])
          {
            int intTemp = 0;
            intTemp = numbers[i];
            numbers[i] = numbers[i + 1];
            numbers[i + 1] = intTemp;
          }
        }
      }
      foreach (int num in numbers)
      {
        Console.WriteLine(num);
      }
      Console.ReadKey();
    }

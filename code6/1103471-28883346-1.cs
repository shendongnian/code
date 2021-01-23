    static void Main(string[] args)
    {
      int[] numbers = new int[9] {1, 5, 10, 2, 1, 45, 64, 99, 232}; 
      int count = numbers.Length;
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

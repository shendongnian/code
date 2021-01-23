    int num = 5;
    String result = String.Join(Environment.NewLine,
      Enumerable.Range(1, num)
        .Reverse()
        .Select((index) =>
          String.Format("Factorial of {0}! = {1}\n",
                        index,
                        Enumerable.Range(1, index).Aggregate(1, (p, item) => p * item))));
    Console.Write(result);

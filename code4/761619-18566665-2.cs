    private static long GetSumOfPrimesBelowviaTPL(int number)
    {
        long sumOfPrimes = 0;
        var primeNumbersList = new BlockingCollection<int>();
        Parallel.For(2, number, i =>
        {
            if ((i == 2 || i % 2 != 0) && (i == 3 || i % 3 != 0) && IsPrime(i))
            {
                primeNumbersList.Add(i);
            }
        });
        primeNumbersList.CompleteAdding();
        foreach (var item in primeNumbersList.GetConsumingEnumerable())
        {
            Console.WriteLine(item);
            sumOfPrimes += item;
        }
        return sumOfPrimes;
    }

    [TestMethod]
    public void One()
    {
        int Min = 0;
        int Max = 10;
        int ArrSize = 1500;
        Stopwatch sw2 = new Stopwatch();
        Stopwatch sw3 = new Stopwatch();
        int[] test2 = new int[ArrSize];
        int[] test3 = new int[ArrSize];
        Random randNum = new Random();
        sw2.Start();
        for (int i = 0; i < test2.Length; i++)
        {
            test2[i] = i;
            Thread.Sleep(10);
            //test2[i] = randNum.Next(Min, Max);
        }
        sw2.Stop();
        Console.WriteLine("Elapsed={0}", sw2.Elapsed);
        sw3.Start();
        Parallel.For(0, test3.Length, (j) =>
        {
            test3[j] = j;
            Thread.Sleep(10);
            //test3[j] = randNum.Next(Min, Max);
        }
            );
        sw3.Stop();
        Console.WriteLine("Elapsed={0}", sw3.Elapsed);
    }

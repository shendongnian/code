    string sName;
    double dAmount;
    int sTotalNames = 0;
    double dAmountTotal = 0;
    double dAmountAverage;
    using (StreamReader sr = new StreamReader("Donations.txt"))
    {
        while (sr.Peek() != -1)
        {
            sName = sr.ReadLine();
            Console.WriteLine(sName);
            dAmount = Convert.ToDouble(sr.ReadLine());
            Console.WriteLine(dAmount);
            dAmountTotal += dAmount;
            sTotalNames++;
        }
        dAmountAverage = dAmountTotal / sTotalNames;
        Console.WriteLine("Sum = {0}", dAmountTotal );
        Console.WriteLine("Total Names = {0}", sTotalNames);
        Console.WriteLine("Average Amount = {0}", dAmountAverage);
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
    }

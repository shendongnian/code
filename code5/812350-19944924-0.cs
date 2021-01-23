    double sum = 0;
    using (StreamReader sr = new StreamReader("Donations.txt"))
    {
        while (sr.Peek() != -1)
        {
            sName = sr.ReadLine();
            Console.WriteLine(sName);
            dAmount = Convert.ToDouble(sr.ReadLine());
            Console.WriteLine(dAmount);
            sum += dAmount;
        }
        Console.WriteLine("Sum = {0}", sum);
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
    }

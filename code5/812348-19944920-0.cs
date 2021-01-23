    List<double> dAmountList = new List<double>();
    using (StreamReader sr = new StreamReader("Donations.txt"))
    {
        while (sr.Peek() != -1)
        {
            sName = sr.ReadLine();
            Console.WriteLine(sName);
            dAmount = Convert.ToDouble(sr.ReadLine());
            Console.WriteLine(dAmount);
            dAmountList.Add(dAmount);
        }
        double sum = dAmountList.Sum(); //here you have your sum
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
    }

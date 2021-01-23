    using (StreamReader sr = new StreamReader(pathToTown))
    {
        var tempLines = new List<string>();
        while (!CityMatch && !sr.EndOfStream)
        {
            string line = sr.ReadLine();
            if (City == line)
            {
                Console.WriteLine("\n\n");
                CityMatch = true;
                int count = tempLines.Count;
                Console.WriteLine("Customer No: {0}", tempLines[count-4]);
                Console.WriteLine("Customer Surname: {0}", tempLines[count - 3]);
                Console.WriteLine("Customer Forename: {0}", tempLines[count - 2]);
                Console.WriteLine("Customer Street: {0}", tempLines[count - 1]);
                Console.WriteLine("Customer Town: {0}", line);
                Console.WriteLine("Customer Day Of Birth: {0}", sr.ReadLine());
                Console.ReadKey();
            }else tempLines.Add(line);
        }
    }

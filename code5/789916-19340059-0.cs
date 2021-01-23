        Console.WriteLine("How many fractions to comapre?");
        string nic = Console.ReadLine();
        int amount = int.Parse(nic);
        double min = 0; double max = 0;
        List<double> finals = new List<double> { };
        for (int i = 0; i < amount; i++)
        {
            Console.WriteLine("Enter fraction to compare. WRITE AS IMPROPER FRCATION");
            string str = Console.ReadLine();
            string[] each = str.Split('/');
            List<double> eachDoub = new List<double> { };
            foreach (string hit in each)
            {
                eachDoub.Add(double.Parse(hit));
            }
            foreach (double hit in eachDoub)
            {
                finals.Add(eachDoub[0] / eachDoub[1]);
            }
        }
        max = finals.Max();
        min = finals.Min();
        Console.WriteLine("The maximum is {0} and the minimum is {1}.", max, min);
        Console.ReadLine();

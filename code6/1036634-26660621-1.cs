      double heighest = 0;
        for (int i = 0; i < 12; i++)
        {
            Console.Write(" Type in {0} number:", i);
            double input = (Convert.ToDouble(Console.ReadLine());
            if (input > heighest)
                heighest = input
        }
        Console.WriteLine("The highest number is {0}", highest);

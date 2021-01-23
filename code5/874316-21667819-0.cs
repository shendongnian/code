    static void Main(string[] args)
    {
        Console.WriteLine("please enter m,y,n: \n");
        string input = Console.ReadLine();
        while (input != "0")
        {
            string[] split = input.Split(' ');
            int month = Int32.Parse(split[0]);
            int year = Int32.Parse(split[1]);
            int numberOfMonths = Int32.Parse(split[2]);
            int i=0;
            for (i = 0; i < numberOfMonths; i++)
            {
                GenMonth(month, year);
                month++;
                Console.Write("\n \n");
            }
            if (month > 12)
            {
                month = 1;
                year++;
            }
            Console.ReadKey();
            Console.WriteLine("please enter m,y,n: \n");
            input = Console.ReadLine();
        }
    }

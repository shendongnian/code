    static void Main(string[] args)
    {
        int month = -1;
        while (true)
        {
            Console.WriteLine("please enter m,y,n: \n");
            string input = Console.ReadLine();
            string[] split = input.Split(' ');
            int month = Int32.Parse(split[0]);
            if (month == 0)
                break;
            int year = Int32.Parse(split[1]);
            int numberOfMonths = Int32.Parse(split[2]);
            ...
            ...
        }
    }

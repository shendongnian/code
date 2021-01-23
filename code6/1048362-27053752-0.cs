    public static void ETA11_3()
    {
        int number = 0, total = 0, option = 0, counter = 0;
        while (true)
        {
            Console.WriteLine("Input a number (zero for stop): ");
            number = Int16.Parse(Console.ReadLine());
            total += number;
            if (number == 0) break;
            counter++;
        }
        Console.WriteLine("Choose an option: ");
        Console.WriteLine("1 - Total");
        Console.WriteLine("2 - Average");
        option = Int16.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
                Console.WriteLine("Total: {0}", total);
                break;
            case 2:
                Console.WriteLine("Total: {0}", total / counter);
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }

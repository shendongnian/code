    Console.WriteLine("Enter 5 numbers to be added together.");
    do 
    {
        DblSumTotal = DblSumTotal + (Convert.ToDouble(Console.ReadLine()));
        LIMIT = LIMIT + 1;
    } while (LIMIT < 6);

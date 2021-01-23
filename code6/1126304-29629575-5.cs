    int number;
    int i, j, k;
    if (int.TryParse(Console.ReadLine(), out number))
    {
        for (i = 0; i < number; i++)
        {
            int numberOfSpaces = i;
            int numberOfStars = (number * 2 - 1) - (2 * numberOfSpaces);
    
            for (j = 1; j <= numberOfSpaces; j++)
            {
                Console.Write(" ");
            }
    
            for (k = 1; k <= numberOfStars; k++)
            {
                Console.Write("*");
            }
    
            Console.WriteLine("");
        }
    }
    else
    {
        Console.WriteLine("No number entered.");
    }
    
    Console.Read();

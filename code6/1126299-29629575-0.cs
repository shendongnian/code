        int number = 5;
        int i, j, k;
        for (i = number; i >= 0; i-=2)
        {
            for (j = 1; j <= (number - i)/2; j++)
            {
                Console.Write(" ");
            }
            for (k = 1; k <= i; k++)
            {
                Console.Write("*");
            }
            for (j = 1; j <= (number - i)/2; j++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("");
        }

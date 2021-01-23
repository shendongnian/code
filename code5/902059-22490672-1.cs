        for (i = 0; i < size; i++)
        {
            Console.WriteLine("Enter number: ");
            int numbers = Convert.ToInt32(Console.ReadLine());
            if (ExistsInArray(number, numbers)) 
            {
                 Console.WriteLine("That was a duplicate. Try again");
                 i--;
            }
            else 
            {
                numbers[i] = number;
            }
        }

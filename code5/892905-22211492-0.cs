        Random random = new Random();
        while(true)
        {
            int num;
            Console.WriteLine("Please enter the amount of sides you want the dice that is being thrown to have. The dice sides available are: 4, 6 and 12: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num == 4 || num == 6 || num == 12)
            {
                int randomDice = random.Next(0, num);
                Console.WriteLine(num + " sided dice thrown, " + randomDice);
            }
            else
            {
                Console.WriteLine("That number is invalid. Please try again.")
            }
            Console.WriteLine("Try again? (yes/no)");
            if(Console.ReadLine().ToLower() != "yes")
                 break;   // end the while loop
        }

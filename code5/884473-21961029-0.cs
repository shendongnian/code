     int guess = 0, number;
     //Create an object of the Random class
     Random rnd = new Random();
     number  = rnd.Next(1, 11);
     for (int i = 0; i < 6; i++)
     {
         Console.Write("Enter Guess :");
         guess = Convert.ToInt32(Console.ReadLine());
         if (guess > number)
         {
              Console.WriteLine("Higher, try again");
         }
         else if (guess < number)
         {
              Console.WriteLine("Lower,  try again");
         }
         else
         {
             Console.WriteLine("You Won !!\t {0} is the correct number", guess);
         }
         if (i == 5)
         {
              Console.WriteLine("You Loose");
         }
         else
         {
              guess = Convert.ToInt32(Console.ReadLine());
         }
      }
      Console.WriteLine("You Loose");
      Console.ReadKey();

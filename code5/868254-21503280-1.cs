    while (true)
    {
         string input = Console.ReadLine();
         decimal result;
         if (decimal.TryParse(input, out result))
         {
              // do your work
              break;
         }
         else
         {
              Console.WriteLine("invalid value try again");
         }
    }

    static void GetChoice(ref int ichoice)
    {
         string input = Console.ReadLine();
         Console.Write("Enter choice: ");   
         bool result = int.TryParse(input, out ichoice);
         if (!result)
         {
              while (!result && ichoice > 3)
              {
                  Console.WriteLine("Invalid value.Try again:");
                  input = Console.ReadLine();
                  result = int.TryParse(input, out ichoice);
              }
          }
    }

      Console.WriteLine("Choose 7 numbers (1-39) by pressing ENTER after every number:");
      int[] userLottery = new int[7];
      int i = 0;
      while (i < 7)
      {
          Console.Write("Your choice #{0}: ", i+1);
          string userRow = Console.ReadLine();
          int userNumber;
          if (!Int32.TryParse(userRow, out userNumber) || userNumber < 1 || userNumber > 39)
          {
              Console.WriteLine("Invalid number! Please try again!");
          }
          else
          {
              userLottery[i++] = userNumber;
          }
      }

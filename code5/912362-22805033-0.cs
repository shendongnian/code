      using System.Text.RegularExpressions;
      Console.WriteLine("Choose 7 numbers (1-39) by pressing ENTER after every number:");
      string userRow = Console.ReadLine();
      int[] userLottery = new int[7];
      string[] userEnter = Regex.Split(userRow, " ");
      int n = 0;
      int k = 0;
      for (int i = 0; i < userEnter.Length; i++)
      {
        bool isNumeric = int.TryParse(userEnter[i], out n);
        if(isNumeric == true)
        {
          userLottery[k] = int.Parse(userEnter[i]);
          k++;
        }
      }

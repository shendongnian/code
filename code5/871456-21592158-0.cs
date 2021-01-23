    for (int i = 0; i < n; i++)
    {
         string value = Console.ReadLine();
         int result;
         if (int.TryParse(value, out result)) arr[i] = result;
         else
         {
             Console.WriteLine("Invalid value try again.");
             i--;
         }
    }

    Console.Write("Enter a number: ");
    string input = Console.ReadLine();
    int n;
    if (int.TryParse(input, out n))
    {
         for (int i = 1; i < n; i++)
         {
              if(i % 3 != 0 ||  i% 7!= 0) Console.WriteLine(i);
         }
    }

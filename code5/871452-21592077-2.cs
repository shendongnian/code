    int n;
    Console.WriteLine("Enter how many values you are entering in");
    n = Convert.ToInt32(Console.ReadLine());
    int[] arr = new int[n];
    Console.WriteLine("Enter your values in");
    for (int i = 0; i < n; i++)
    {
      char c = Console.ReadKey().KeyChar;
      arr[i] = Convert.ToInt32(c.ToString());
    }
       

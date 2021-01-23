    while (true)
    {
      Console.WriteLine("Please enter Q to Quit or continue  ");
      cont = Convert.ToChar(Console.ReadLine().ToUpper());
      if (cont == 'Q') break;
      Console.WriteLine("Please enter First value  ");
      value1 = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Please enter Second value  ");
      value2 = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Please enter  operator   ");
      op = Convert.ToChar(Console.ReadLine());
      if (op == '+')
      {
        result = value1 + value2;
        Console.WriteLine("Result is : {0}", result);
      }
    }

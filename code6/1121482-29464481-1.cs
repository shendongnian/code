    Console.WriteLine("How many times would you like to roll?");
    string count = Console.ReadLine();
    int cnt = Convert.ToInt32(count);
    Random roll = new Random();
    for (int i = 1; i <= cnt; i++) {
      int rol = new int();
      rol = roll.Next(1, 7);
      Console.WriteLine("Die {0} landed on {1}.", i, rol);
    }
    Console.ReadLine();

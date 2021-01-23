    int custom = 0;
    if(int.TryParse(Console.ReadLine(), out custom)) {
      Console.WriteLine(DateTime.Now.AddHours(custom));
    }
    else {
      Console.WriteLine("Invalid number!");
    }

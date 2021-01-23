    DateTime beginWait = DateTime.Now;
    while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < 60)
        Thread.Sleep(250);
    if (!Console.KeyAvailable)
        Console.WriteLine("You didn't press anything!");
    else
        Console.WriteLine("You pressed: {0}", Console.ReadKey());

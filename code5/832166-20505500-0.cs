    var MyEventThrower = new EventThrower();
    var log= new List<string>();
    log.Add("Log Initialized");
    MyEventThrower.Event += (sender, args) => log.Add(sender.ToString());
    MyEventThrower.RaiseEvent();
    foreach (var item in log)
    {
        Console.WriteLine(item);
    }

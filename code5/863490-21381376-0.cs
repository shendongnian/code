    List<string> list = new List<string>();
    DateTime midnight = DateTime.Today;
    while (midnight < DateTime.Today.AddDays(1))
    {
        list.Add(midnight.ToString("HH:mm"));
        midnight = midnight.AddMinutes(1);
    }
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }

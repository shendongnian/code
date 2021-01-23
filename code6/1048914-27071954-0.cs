    var time = dateTime.TimeOfDay;
    if (time.Hours < 12)
    {
        Console.WriteLine("Morning");
    }
    else if (time.Hours < 18)
    {
        Console.WriteLine("Afternoon");
    }
    else
    {
        Console.WriteLine("Evening");
    }

    DateTime endDate = DateTime.Today;
    for (DateTime dt = startDate; dt <= endDate; dt = dt.AddMonths(1))
    {
        Console.WriteLine("{0:M/yyyy}", dt);
    }

    TimeSpan okFrom = new TimeSpan(2, 0, 0),
             okTo =   new TimeSpan(6, 0, 0);
    
    var files = new DirectoryInfo(@"X:\").GetFiles("*.*");
    foreach (var i in files)
    {
        if (i.CreationTime.TimeOfDay >= okFrom && i.CreationTime.TimeOfDay <= okTo)
            Console.WriteLine("File created before 6:30 in the morning\n\t{0} -> {1}", i.Name, i.CreationTime.ToString());
    }

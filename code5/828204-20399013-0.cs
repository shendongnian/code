    // Load the data
    double[] array1 = new double[] {
        1d,
        2d,
        3d,
        4d,
        5d
    };
    double searchValue = 5;
    if (array1.Contains(searchValue))
    {
        Console.WriteLine("Found " + searchValue);
    }
    else
    {
        Console.WriteLine("*NOT* Found " + searchValue);
    }

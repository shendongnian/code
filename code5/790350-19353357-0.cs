    if (pizzaDiameter <= XL_MAX || pizzaDiameter >= SMALL_MIN)
    {
        if (pizzaDiameter >= SMALL_MIN || pizzaDiameter < SMALL_MED)
        {
            numberOfSlices = (SMALL_SLICE);
        }
        ...
        else  // Note, you do not need the final `if` in this block
        {
            numberOfSlices = (XL_SLICES);
        }
        radius = pizzaDiameter/2;
        sliceArea = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine("\nA diameter of " + pizzaDiameter + " will yield." + numberOfSlices + " slices.");
        Console.WriteLine("\nEach slice will have an area of " + sliceArea + "\".");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine(" Entry Error ");
        Console.WriteLine("Pizza must have args diameter in the range of 12\" to 36\" inclusive!");
        Console.WriteLine("please try again");
        Console.WriteLine(" /nPress any key to end this application...");
        Console.ReadKey();
    }

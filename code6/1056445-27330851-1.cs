    intarray = new int[nr];
    for (int i = 0; i < nr; i++)
    {
        intarray[i] = generateRandom(4);
        Console.WriteLine(intarray[i] + "Test1 " + i);
    }
    
    for (int i = 0; i < intarray.Length; i++)
    {
        Console.WriteLine(intarray[i] + "Test2 " + i);
    }

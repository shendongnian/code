    int value = 35;
    int[] list = new[] { 1, 8, 13, 20, 25, 32, 50, 55, 64, 70 };
    int? floor = null;
    int? ceil = null;
    int index = Array.BinarySearch(list, value);
    if (index >= 0) // element is found
    {
        if (index > 0)
            floor = list[index - 1];
        if (index < list.Length - 1)
            ceil = list[index + 1];
    }
    else
    {
        index = ~index;
        if (index < list.Length)
            ceil = list[index];
        if (index > 0)
            floor = list[index - 1];
    }
    Console.WriteLine("floor = {0}", floor);
    Console.WriteLine("ceil = {0}", ceil);

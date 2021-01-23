    int desiredTotal = 300; 
    float[] widths = new float[] { 35f, 63f, 12f };
    float ratio = desiredTotal / widths.Sum();
    var normalizedList = widths.Select(o => o * ratio).ToList();
    foreach (var item in normalizedList)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine(normalizedList.Sum());
    /* Which prints:
    95.45454
    171.8182
    32.72727
    300
    */

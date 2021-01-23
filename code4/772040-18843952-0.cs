    double[] tips = new double[7];
    for (int i = 0; i < tips.Length; i++)
    {
        Console.Write("Please enter the amount of tips earned by waiter #" + i + ".");
        tips[i] = double.Parse(Console.ReadLine());
    }
    double average = tips.Average();
    for (int i = 0; i < tips.Length; i++)
    {
        Console.Write("Tip #" + i + " is: " + tips[i] + " - The difference between the average is: " + (tips[i] - average));
    }
    Console.ReadLine()

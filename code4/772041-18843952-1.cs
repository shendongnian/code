    double[] tips = new double[7];
    for (int i = 0; i < tips.Length; i++)
    {
        Console.Write("Please enter the amount of tips earned by waiter #" + i + ".");
        tips[i] = double.Parse(Console.ReadLine());
    }
    double average = tips.Average();
    //without linq
    /*
    double sum = 0;
    for (int i = 0; i < tips.Length; i++)
    {
        sum = sum + tips[i];
    }
    double average = sum / tips.Length;
    */
    for (int i = 0; i < tips.Length; i++)
    {
        Console.Write("Tip #" + i + " is: " + tips[i] + " - The difference between the average is: " + Math.Abs(tips[i] - average));
    }
    Console.ReadLine()

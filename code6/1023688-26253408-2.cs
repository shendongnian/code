    var values = new long[]
    {
            TimeSpan.Parse("0:22:49").Ticks,
            TimeSpan.Parse("0:08:00").Ticks,
            TimeSpan.Parse("0:06:31").Ticks
    };
    var sum = values.Sum();
    var avg = (long)values.Average();
    var stdev = (long)Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
    var total = TimeSpan.FromTicks(sum);
    var average = TimeSpan.FromTicks(avg); ;
    var standardev = TimeSpan.FromTicks(stdev); ;
    Console.WriteLine("Sum: " + total);
    Console.WriteLine("Avg: " + average);
    Console.WriteLine("StDev: " + standardev);

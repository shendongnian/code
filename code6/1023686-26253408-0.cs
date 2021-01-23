    var values = new double[]
    {
            TimeSpan.Parse("0:22:49").TotalMilliseconds,
            TimeSpan.Parse("0:08:00").TotalMilliseconds,
            TimeSpan.Parse("0:06:31").TotalMilliseconds
    };
    var sum = values.Sum();
    var avg = sum / 3; 
    var total = TimeSpan.FromMilliseconds(sum);
    var average = TimeSpan.FromMilliseconds(avg); ;
    Console.WriteLine("Sum: " + total);
    Console.WriteLine("Avg: " + average);

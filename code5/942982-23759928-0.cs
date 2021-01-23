    String str = "BB6050C9";
    const int chunkSize = 2;
    var sum = Enumerable.Range(0, str.Length / chunkSize)
    		.Select(x => str.Substring(x * chunkSize, chunkSize))
    		.Sum(x => int.Parse(x, System.Globalization.NumberStyles.HexNumber));
    Console.WriteLine(sum);

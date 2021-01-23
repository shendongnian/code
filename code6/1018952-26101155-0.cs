    using System;
    using System.IO;
    using System.Linq;
    String path = @"MyFolder\myfile.txt"; // path for your file
    // read the file
    String[] lines = File.ReadAllLines(path);
    // convert data in Doubles    
    Double[] data = Array.ConvertAll(lines, Double.Parse);
    // use Linq to get what you want (min, max, total, average, ...)
    Double low = data.Min();
    Double high = data.Max();
    Double total = data.Sum();
    Double average = data.Average();

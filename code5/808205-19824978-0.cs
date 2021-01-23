    Tuple<double[][], string[]> GetElections()
    {
        var file = @"C:\Users\Deines\Documents\Election2008.txt";
        var fileAsLines = File.ReadLines(file).Select(line => line.Split(','));
        var dataset = fileAsLines.Select(line => new[] 
                                                 { 
                                                     Convert.ToDouble(line[1]),
                                                     Convert.ToDouble(line[2]),
                                                     Convert.ToDouble(line[3])
                                                 }).ToArray();
        var labels = fileAsLines.Select(line => line[4]).ToArray();
        return Tuple.Create(dataset, labels);
    }

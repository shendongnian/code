    class ElectionResult
    {
         public ElecationResult(string label, double x, double y, int amount)
         {
             this.Label = label;
             this.Point = new Point(x,y);
             this.Amount = amount;
         }
         string Label { get; private set; }
         Point Location { get; private set; }
         int Amount { get; private set; }
    }
    IList<ElectionResult> GetElectionResults()
    {
        var file = @"C:\Users\Deines\Documents\Election2008.txt";
        var fileAsLines = File.ReadLines(file).Select(line => line.Split(','));
        return fileAsLines.Select(line => new ElectionResult(line[4],
                                                     Convert.ToDouble(line[1]),
                                                     Convert.ToDouble(line[2]),
                                                     Convert.ToInt32(line[3]))
                          .ToList();
    }

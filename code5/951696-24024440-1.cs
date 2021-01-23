    string[] values = new[] { "1", "2", "3", "1.5", "56.5", "8" };
    var file = values.AsParallel()
                     .Select(s => Double.Parse(s))
                     .Select(d => (int)Math.Round(d))
                     .Select(i => Math.Abs(i).ToString())
                     .ToArray();

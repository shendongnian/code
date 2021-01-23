    var sources = new List<string> { "baseline", "items" };
    Baseline =
        Math.Round(Mutations.Where(n => n.Format.Is("Numeric"))
            .Where(n => sources.Intersect(n.Sources).Any())
            .Sum(n => n.Measurement), 3);

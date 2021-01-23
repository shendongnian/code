    var firstOfEachGroup = dbContext.Measurements
                        .OrderByDescending(m => m.MeasurementId)
                        .GroupBy(m => new { m.SomeColumn })
                        .Where(g => g.Count() > 1)
                        .SelectMany(g => g.Skip(1));

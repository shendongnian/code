    var result = items.Where(b => b.Year == year)
        .GroupBy(b => b.MonthID)
        .Select(
            g => new {
                MonthID = g.Key,
                TotalElectricity = g.Sum(b => b.Electricity),
                TotalPhone = g.Sum(b => b.Phone),
                TotalWater = g.Sum(b => b.Water),
                TotalGas = g.Sum(b => b.Gas)
            }
        );

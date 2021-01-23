    var consolidatedData = GetData()
            .GroupBy(t => t.DivisionId)
            .Where(g => g.Skip(1).Any(i => i.DivisionId != 0))
            .Select(g => new
            {
                TotalSales = -(g.Sum(n => n.TotalSales) - g.Average(n => n.TotalSales)),
                TotalPurchases = -(g.Sum(n => n.TotalPurchases) - g.Average(n => n.TotalPurchases))
            });
    var overallSales = consolidatedData.Sum(i => i.TotalSales);
    var overallPurchases = consolidatedData.Sum(i => i.TotalPurchases);

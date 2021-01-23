    DataContext context = new DataContext();
    var invoiceTotalsByMonthQuery = from i in context.Invoices
                                    group i by new { i.Date.Year, i.Date.Month } into g
                                    select new
                                    {
                                        Year = g.Key.Year,
                                        Month = g.Key.Month,
                                        Customer = g.GroupBy(x => x.Customer)
                                                    .Select(x => new { Name = x.Key, Total = x.Sum(y => y.Amount)})
                                                    .OrderByDescending(x => x.Total)
                                                    .First()
                                    };
    var invoiceTotalsByMonth = invoiceTotalsByMonthQuery.OrderBy(x => x.Year)
                                                        .ThenBy(x => x.Month);
    foreach(var item in invoiceTotalsByMonth)
    {
        Console.WriteLine("{0}/{1} - {2} ({3})", item.Month, item.Year, item.Customer.Name, item.Customer.Total);
    }

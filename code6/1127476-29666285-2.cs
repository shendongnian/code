    var monthlyGroup = aBar.OrderBy(bar => bar.stockDate)
                           .GroupBy(bar => new { Year = bar.stockDate.Year, Month = bar.stockDate.Month })
                            //create bars from groups
                           .Select(g => new bar()
                                {
                                    open = g.First().open,
                                    high = g.Max(b => b.high),
                                    low = g.Min(b => b.low),
                                    close = g.Last().close,
                                    volume = g.Average(b => b.volume),
                                    stockDate = new DateTime(g.Key.Year, g.Key.Month, 1)
                                })
                           .ToList();

    var monthlyGroup = aBar.GroupBy(bar => new { Year = bar.stockDate.Year, Month = bar.stockDate.Month })
                            //create bars from groups
                           .Select(g => new bar()
                                {
                                    open = g.Average(b => b.open),
                                    high = g.Max(b => b.high),
                                    low = g.Min(b => b.low),
                                    close = g.Average(b => b.close),
                                    volume = g.Average(b => b.volume),
                                    stockDate = new DateTime(g.Key.Year, g.Key.Month, 1)
                                })
                           //un-comment following line if you need to sort*
                         /*.OrderBy(b => b.stockDate)*/
                           .ToList();

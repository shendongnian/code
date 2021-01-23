    var query = data.OrderBy(item => item.Date)
                    .GroupWhile((previous, current) => 
                        previous.Date.AddDays(1) == current.Date
                        && previous.Price == current.Price)
                    .Select(group => new
                    {
                        DateMin = group.First().Date,
                        DateMax = group.Last().Date,
                        Count = group.Count(),
                        Price = group.First().Price,
                    });

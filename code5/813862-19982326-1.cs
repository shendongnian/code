    var distinctIdsWorking = promoCodeValues.AsEnumerable()
                    .Select(s => new
                    {
                        id = s.Value,
                    })
                    .Distinct().ToList();

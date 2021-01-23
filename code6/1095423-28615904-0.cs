    var min = dictionary
                .OrderBy(pair => pair.Value)
                .Select(pair =>
                    new
                    {
                        k = pair.Key,
                        d = Math.Abs(pair.Key - price)
                    })
                .OrderBy(t => t.d)
                .Select(t => t.k)
                .FirstOrDefault();

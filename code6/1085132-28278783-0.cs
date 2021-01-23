    var tst = repositoryIpFrom
                .Where(s=>s.id == id)
                .ToList()
                .GroupBy(s => s.Country)
                .Select(n => new
                {
                   Country = n.Key,
                   Count = n.Count()
                });

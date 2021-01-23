    var tst = repositoryIpFrom
                .Where(s=>s.id == id)
                .AsEnumerable()
                .GroupBy(s => s.Country)
                .Select(n => new
                {
                   Country = n.Key,
                   Count = n.Count()
                });

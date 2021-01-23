    var query = DbProvider.DB
        .AsEnumerable()
        .Where(p => p.Accepte.HasValue && p.Accepte.Value)
        .OrderByDescending(p => p.Score).Select((user, index) => new 
                {
                    user.Id,
                    user.Score,
                    index
                })
        .FirstOrDefault(user => user.Id == Id);

    var results = _context.SqlQuery<UserItemProcDto>(query, paramUserId);
    var usersWithItems = results.GroupBy(r => r.UserId)
        .Select(g => new User
        {
            UserId = g.Key,
            Name = g.First().UserName,
            Items = g.Select(i => new Item
            {
                ItemId = i.ItemId,
                Name = i.ItemName
            }).ToList()
        });

    var query = DbContext.Clients
        .Where(c => c.FamilyNames.Any(fn => fn == textEnteredByUser))
        .Select(c => new {
            ClientName = c.Name,
            FamilyNames = c.FamilyNames.ToList()
        });

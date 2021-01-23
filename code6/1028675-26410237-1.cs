    var restrictTo = new[] {1, 2};
    var query = tableARepository.AsQueryable()
        // I want to add where clause like tableA.Id in (1,2)
        .Where(a => restrictTo.Contains(a.Id))
        .Select(a => new {
            Id = a.Id
        ,   Name = a.Name
        ,   FkId = tableBRepository.AsQueryable().Min(b => b.fkid=a.id)
        });

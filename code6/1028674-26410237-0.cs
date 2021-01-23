    var query = tableARepository.AsQueryable()
        .Select(a => new {
            Id = a.Id
        ,   Name = a.Name
        ,   FkId = tableBRepository.AsQueryable().Min(b => b.fkid=a.id)
        });

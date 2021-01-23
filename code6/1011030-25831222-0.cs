    _uow.Repository<A>()
        .All()
        .Select(a => new AViewModel
        {
            Id = a.Id,
            Name = a.Name,
            Bs = a.Bs.Select(b => new BViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Cs = b.Cs.Select(c => new CViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
             }).ToList()
        })
        .FirstOrDefault(a => a.Id == Id);

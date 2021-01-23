    var res = model.UserSet.Where(u => u.name != "");
    if (withchildren) {
        res = res.Select(u => new {
                 Name = u.name,
                 Email = u.email,
                 Groups = u.GroupSet.Select(g => new {
                    Name = g.name,
                    Id = g.Id
                 })
              });
    } else {
        res = res.Select(u => new {
                Name = u.name,
                Email = u.email
            });
    }

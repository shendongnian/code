    res = model.UserSet
        .Where(u => u.name != "")
        .ToList()                        // ToList() here to enumerate the items
        .Select(u => {
            dynamic item = new { 
                Name = u.name,
                Email = u.email
            };
            if(withchildren) {
                item.Groups = u.GroupSet.Select(g => new {
                    Name = g.name,
                    Id = g.Id
                });
            }
            return item;
        });

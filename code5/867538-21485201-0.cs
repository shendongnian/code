    public SelectList GetAsSelectList()
            {
                var depts = from d in GetAll()
                            select new
                            {
                                Id = d.Id,
                                Name = d.Name
                            };
    
                return new SelectList(depts, "Id", "Name");
            }

                 var attributes =
                                    (from attr in model.CategoryAttributes.Include(c => c.Children)
                                     where attr.ParentID == null
    //Edited Here
                                     select new
                {
                    Name = attr.Value,
                    ID = attr.ID,
                    Children = attr.Children
                    .Select(c => new AttributeObject() { Name = c.Value, ID = c.ID })
                            .ToList()
                })
    //and Here
    .AsEnumerable()
                .Select(n => 
                    new AttributeObject() {
                Name=n.Name,
                ID=n.ID,
                Children=n.Children
                
                }).ToList();

     var attributes =
                        (from attr in model.CategoryAttributes.Include(c => c.Children)
                         where attr.ParentID == null
                         select new AttributeObject()
                         {
                             Name = attr.Value,
                             ID = attr.ID,
                             Children = attr.Children.AsEnumerable()
                            .Select(c=>new AttributeObject(){ID=c.ID,Name=c.Value })
                            .ToList()
                     });

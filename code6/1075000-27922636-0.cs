        var query = (from p in parents
                         select new
                         {
                             ParentID = p.ID,
                             Description = p.Description,
                             PrimaryChildID = children.Where(c => c.ParentID == p.ID && c.Condition == null).Count() == 0 ? 0 : children.OrderBy(c=>c.ID).FirstOrDefault(c => c.ParentID == p.ID && c.Condition == null).ID,
                             SubDescription = children.Where(c => c.ParentID == p.ID && c.Condition == null).Count() == 0 ? null : children.OrderBy(c => c.ID).FirstOrDefault(c => c.ParentID == p.ID && c.Condition == null).Description,
                             ConditionalCount = children.Where(c => c.ParentID == p.ID && c.Condition != null).Count()
                         }).ToList();

    var dicTags= dbContext.PostTagRelation
       .Where(x => posts.Any(g => g.ItemId == x.ItemId && g.Medium == x.Medium) && x.Company == companyId)
       //force execution of the query
       .ToList() 
       //now you have an IEnumerable instread of IQueryable
       .ToDictionary(g => g.ItemId, g => g.Tags) 

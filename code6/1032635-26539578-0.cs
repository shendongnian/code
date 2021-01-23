	var categoryID = 2; //The ID you are searching for
	
	var data = from c in categories
	           where c.Id == categoryID 
	           select new Category
			   {
			   	   Id = c.Id,
				   Name = c.Name,
				   ParentId = c.ParentId,
				   IsDeleted = c.IsDeleted,
				   Timestamp = c.Timestamp,
				   Parent = c.Parent,
				   Parents = c.Parents,
			       Images = c.Images == null ? 
                       (ICollection<Image>)new List<Image>() : 
                       (ICollection<Image>)c.Images.Where(i => i.IsDeleted = false).ToList()
			   };

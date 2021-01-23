    var final = new Dictionary<string, Category>();
    var rootCategories = new List<Category>();
    // Pass 1
    foreach (var flat in flatList)
    {
      Category cat = new Category() { ID = flat.ID, Name = flat.Name, parent = null }
      cat.Children = new List<Category>();
      final[flat.ID] = cat;
    }
    // Pass 2
    foreach (var flat in flatList)
    {
      // find myself -- must exist
      var self = final[flat.ID];
      // find parent -- may not exist
      if (final.ContainsKey(flat.ParentID)
      {
        var parent = final[flat.ParentID];
        parent.Children.Add(self);
        self.Parent = parent;     
      }
      else
      {
        rootCategories.Add(self);
      }
    }

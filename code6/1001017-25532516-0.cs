    var final = new Dictionary<string, Category>();
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
      // find myself
      var self = final[flat.ID];
      // find parent
      var parent = final[flat.ParentID];
      parent.Children.Add(self);
      self.Parent = parent;     
    }

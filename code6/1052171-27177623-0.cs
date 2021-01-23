    public void Update(UpdateParentModel model)
    {
        var existingParent = _dbContext.Parents
            .Where(p => p.Id == model.Id)
            .Include(p => p.Children)
            .SingleOrDefault();
        if (existingParent != null)
        {
            // Update parent
            _dbContext.Entry(existingParent).CurrentValues.SetValues(model);
            // Delete children
            foreach (var existingChild in existingParent.Children.ToList())
            {
                if (!model.Children.Any(c => c.Id == existingChild.Id))
                    _dbContext.Children.Remove(existingChild);
            }
            // Update and Insert children
            foreach (var childModel in model.Children)
            {
                var existingChild = existingParent.Children
                    .Where(c => c.Id == childModel.Id)
                    .SingleOrDefault();
                if (existingChild != null)
                    // Update child
                    _dbContext.Entry(existingChild).CurrentValues.SetValues(childModel);
                else
                {
                    // Insert child
                    var newChild = new Child
                    {
                        Data = childModel.Data,
                        //...
                    };
                    existingParent.Children.Add(newChild);
                }
            }
            _dbContext.SaveChanges();
        }
    }

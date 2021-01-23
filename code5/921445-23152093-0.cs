    protected override void Seed(IdentityDb context)
    {
        **//This is the seed method I want to run when I update the database:**
        if(!context.CategorySet.Any(c => c.Name == "Root"))
        {
            Category mainCategory = new Category { Id = Guid.NewGuid(), Name = "Root",   Parent = null };
            context.CategorySet.Add(mainCategory);
            context.SaveChanges();
        }
    }

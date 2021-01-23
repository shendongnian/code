    using (var context = new MyContext())
    {
        // as said, the following line should be your default
        context.Configuration.AutoDetectChangesEnabled = true;
        var child = context.Children.SingleOrDefault(c => c.Id == childId);
        if (child != null)
        {
            child.ParentId = null;
            context.SaveChanges();
        }
    }

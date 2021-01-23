    public bool Delete()
    {
        using (var context = new DbContext())
        {
            context.MyEntityType.Remove(this); 
            //context.DeleteObject(this); <- in older versioned context
            context.SaveChanges();
        }
    }

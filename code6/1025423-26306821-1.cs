    try
    {
        using (var ac = new ApplicationDbContext())
        {
            // Add non-unique data
            ac.SaveChanges();
        }
    }
    catch (DbUpdateException ex)
    {
        // Handle index error
    }

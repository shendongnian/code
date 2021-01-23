    void UpdateCommandExecute()
    {
        using (_context = new BenchMarkEntities())
        {                
            _context.SaveChanges();
        }
    }

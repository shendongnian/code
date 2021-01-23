    public IEnumerable<Owner> GetAll(int userId)
    {
        return _dbContext.Owners.Where(x => x.UserId == userId)
            .GroupBy(p => p.Text).Select(x => x.First()).ToList();
    }

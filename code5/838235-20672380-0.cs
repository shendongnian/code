    public List<Record> Search(string[] keywords)
    {
        var result = (from c in _context.Tenders
                      where keywords.Any(w => c.Title.Contains(w)) || keywords.Any(w => c.Summary.Contains(w))
                      select new Record()
                      {
                          Id = c.Id,
                          Title = c.Title,
                          Content = c.Summary
                      }).ToList();
        return result;
    }

    var transportsToDuplicate = Context.Transports
                                       .AsNoTracking()
                                       .Where(t => ids.Contains(t.Id))
                                       .Include(c => c.Documents.Select(d => d.File))
                                       .ToList();
    transportsToDuplicate.ForEach(t => Context.Transports.Add(t));

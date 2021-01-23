    Table table = _context.Table.AsNoTracking().Select(s => new Table {
	 // some properties, exept id
        }).FirstOrDefault();
    _context.Table.Add(table);
    await _context.SaveChangesAsync();

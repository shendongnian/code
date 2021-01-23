    var isFirstValid = !string.IsNullOrWhiteSpace(first);
    var isLastValid = !string.IsNullOrWhiteSpace(last);
    var query = db.Names
      .AsQueryable()
      .Where(name =>
        (isFirstValid && name.first.Contains(first)) ||
        (isLastValid && name.last.Contains(last))
      )
      .ToList();

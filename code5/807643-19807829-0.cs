    IEnumerable<whatever> q = source;
    if (!string.IsNullOrEmpty(searchText))
    {
        q = q.Where(item => item.Name.Contains(searchText));
    }
    if (startDate.HasValue)
    {
        q = q.Where(item => item.Date > startDate.Value);
    }

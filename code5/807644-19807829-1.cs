    IEnumerable<whatever> q = source;
    if (!string.IsNullOrEmpty(searchText))
    {
        q = q.Where(item => item.Name.Contains(searchText));
    }
    if (startDate.HasValue)
    {
        // What is the runtime type of q? And what is its compiletime type?
        q = q.Where(item => item.Date > startDate.Value);
    }

    IEnumerable<LogEntry> Group(IEnumerable<LogEntry> entries)
    {
        List<LogEntry> result = new List<LogEntry>();
        var groups = entries.GroupBy(e => e.Id);
        foreach (var group in groups)
        {
            var children = group.SelectMany(e => e.Children);
            if (children.Any())
            {
                var key = group.First();
                LogEntry newItem = new LogEntry { Id = key.Id, Name = key.Name };
                newItem.Children.AddRange(Group(children));
                result.Add(newItem);
            }
            else
            {
                result.AddRange(group);
            }
        }
        return result;
    }

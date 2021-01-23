    enum Priority : byte
    {
        High = 0,
        Medium = 1,
        Low = 2
    }
    Dictionary<char, Priority> _map = new Dictionary<char, Priority>() {
        { 'h', Priority.High }, { 'H', Priority.High },
        { 'm', Priority.Medium }, { 'M', Priority.Medium },
        { 'l', Priority.Low }, { 'L', Priority.Low }
    };
    Priority GetPriority(string field)
    {
        Priority res;
        if (!TryGetPriority(field, out res))
            throw new ArgumentException("Invalid priority on field.", "field");
        return res;
    }
    bool TryGetPriority(string field, out Priority priority)
    {
        if (field == null || field.Length == 0) { priority = default(Priority); return false; }
        return _map.TryGetValue(field[0], out priority);
    }

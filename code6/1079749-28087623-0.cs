    public ItemEvents(int id, IEnumerable<Event> events)
    {
        this.id = id;
        shops = events.Where(e => e.Type.Contains("PURCHASED"))
                      .ToDictionary(e => e.timestamp, e => e.item);
        // Ditto for the other dictionaries.
    }

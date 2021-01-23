    ( ( IEnumerable<int> )Enum.GetValues(typeof(Colors)) )
        .Select(ev =>
        new Color()
        {
            Value = ev,
            Name = Enum.GetName(typeof(Colors), ev)
        })
        .ToList();

    target = new ReadOnlyDictionary<string, IReadOnlyDictionary<Guid, int>>(
        data.ToDictionary<string, IReadOnlyDictionary<Guid, int>>(
                i => i.Item,
                v => new ReadOnlyDictionary<Guid, int>(
                    v.Values.ToDictionary(
                        a => Guid.NewGuid(),
                        b => b))));

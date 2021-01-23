    target = new ReadOnlyDictionary<string, IReadOnlyDictionary<Guid, int>>(
        data.ToDictionary(
                i => i.Item,
                v => (IReadOnlyDictionary<Guid, int>)new ReadOnlyDictionary<Guid, int>(
                    v.Values.ToDictionary(
                        a => Guid.NewGuid(),
                        b => b))));

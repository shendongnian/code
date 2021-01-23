     public static int? Match(int start_index, string searchTerm)
        {
            var wanted = _properties
                .Select((prop,i) => new { Index = i, Item = prop(_itemType) })
                .Skip(start_index)
                .FirstOrDefault(value => value.Item != null && value.Item.ToLower().Contains(searchTerm.ToLower()));
            return wanted==null ? null : (int?)wanted.Index;
        }

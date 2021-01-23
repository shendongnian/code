    private static IEnumerable<IndexEntry> GetIndexEntries(Person person)
    {
        var indexEntries = new List<IndexEntry>
        {
            new IndexEntry
            {
                Name = "Persons",
                KeyValues = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", person.Name),
                    new KeyValuePair<string, object>("id", person.Id)
                }
            }
        };
        return indexEntries;
    }

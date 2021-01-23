    [ProtoContract]
    class Foo
    {
        private readonly SortedDictionary<string, int> items =
            new SortedDictionary<string, int>(
            StringComparer.InvariantCultureIgnoreCase);
        [ProtoMember(1)]
        SortedDictionary<string, int> Items { get {  return items; } }
    }

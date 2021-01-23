        class ConnectionContainer
        {
            private readonly List<Item> _items;
            private readonly List<ConnectionInfo> _connections;
            public ConnectionContainer(IEnumerable<Item> items)
            {
                _items = items.ToList();
                Connections = items.SelectMany(i => i.Connections).Distinct().Select(c => new ConnectionInfo
                {
                    Type = c.Type,
                    SourceId = c.Source.ID,
                    TargetId = c.Target.ID
                }).ToList();
            }
            public List<Item> Items
            {
                get { return _items; }
            }
            public List<ConnectionInfo> Connections
            {
                get { return _connections; }
            }
        }
        class ConnectionInfo
        {
            private ConnectionType Type { get; set; }
            private int SourceId { get; set; }
            private int TargetId { get; set; }
        }

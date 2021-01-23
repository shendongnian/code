    public TableMapping GetMapping(Type type, CreateFlags createFlags = CreateFlags.None)
	{
		if (_mappings == null) {
			_mappings = new Dictionary<string, TableMapping> ();
		}
        lock (_mappings)
        {
            TableMapping map;
            if (!_mappings.TryGetValue(type.FullName, out map))
            {
                map = new TableMapping(type, createFlags);
                _mappings[type.FullName] = map;
            }
            return map;
        }	
	}

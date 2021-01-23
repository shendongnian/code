    IDictionary<ABC, ICollection<DEF>> data = new Dictionary<ABC, ICollection<DEF>>();
    int _a = reader.GetOrdinal("a"), _b = reader.GetOrdinal("b"), _c = reader.GetOrdinal("c");
	int _value = reader.GetOrdinal("value"), _comment = reader.GetOrdinal("comment");
    while (reader.Read()) {
        ABC key = new ABC { A = reader.GetInt32(_a), B = reader.GetString(_b), C = reader.GetInt32(_c) };
		ICollection<DEF> values;
		if (!data.TryGetValue(key, out values)) {
			data[key] = (values = new List<DEF>());
		}
		values.Add(new DEF { value = reader.GetInt32(_value), comment = reader.GetString(_comment) });
    }

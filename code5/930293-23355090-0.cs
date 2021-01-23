	public void Foo<T>(IDictionary<string, T> data)
		where T : ICollection<string>, new()
	{
		var col = new T();
		col.Add("bar");
		data["col"] = col;
	}

	readonly Func<IDataReader, T> _converter;
	readonly IDataReader dataReader;
	private Func<IDataReader, T> GetMapFunc()
	{
		var exps = new List<Expression>();
		var paramExp = Expression.Parameter(typeof(IDataRecord), "o7thDR");
		var targetExp = Expression.Variable(typeof(T));
		exps.Add(Expression.Assign(targetExp, Expression.New(targetExp.Type)));
		//does int based lookup
		var indexerInfo = typeof(IDataRecord).GetProperty("Item", new[] { typeof(int) });
		var columnNames = Enumerable.Range(0, dataReader.FieldCount)
									.Select(i => new { i, name = dataReader.GetName(i) });
		foreach (var column in columnNames)
		{
			var property = targetExp.Type.GetProperty(
				column.name,
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
			if (property == null)
				continue;
			var columnNameExp = Expression.Constant(column.i);
			var propertyExp = Expression.MakeIndex(
				paramExp, indexerInfo, new[] { columnNameExp });
			var convertExp = Expression.Convert(propertyExp, property.PropertyType);
			var bindExp = Expression.Assign(
				Expression.Property(targetExp, property), convertExp);
			exps.Add(bindExp);
		}
		exps.Add(targetExp);
		return Expression.Lambda<Func<IDataReader, T>>(
			Expression.Block(new[] { targetExp }, exps), paramExp).Compile();
	}
	internal Converter(IDataReader dataReader)
	{
		this.dataReader = dataReader;
		_converter = GetMapFunc();
	}
	internal T CreateItemFromRow()
	{
		return _converter(dataReader);
	}

		private static List<string> columnNames;
		
		private static Action<IDataReader, T> GetMapFunc()
		{
			var exps = new List<Expression>();
		
			var paramExp = Expression.Parameter(typeof(IDataRecord), "o7thDR");
			var targetExp = Expression.Parameter(typeof(T), "o7thTarget");
		
			var getPropInfo = typeof(IDataRecord).GetProperty("Item", new[] { typeof(string) });
		
			foreach (var columnName in columnNames)
			{
				var property = typeof(T).GetProperty(columnName);
				if (property == null)
					continue;
				// use 'columnName' instead of 'property.Name' to speed up reader lookups
				//in case of certain readers.
                var columnNameExp = Expression.Constant(columnName);
                var getPropExp = Expression.MakeIndex(
                    paramExp, getPropInfo, new[] { columnNameExp });
				var castExp = Expression.TypeAs(getPropExp, property.PropertyType);
				var bindExp = Expression.Assign(
					Expression.Property(targetExp, property), castExp);
				exps.Add(bindExp);
			}
			return Expression.Lambda<Action<IDataReader, T>>(
				Expression.Block(exps), paramExp, targetExp).Compile();
		}
		
		internal T CreateItemFromRow(IDataReader dataReader)
		{
			if (columnNames == null)
			{
				columnNames = Enumerable.Range(0, dataReader.FieldCount)
										.Select(x => dataReader.GetName(x))
										.ToList();
				_convertAction = (Action<IDataReader, T>)_convertActionMap.GetOrAdd(
					typeof(T), (t) => GetMapFunc());
			}
		
			T result = new T();
			_convertAction(dataReader, result);
			return result;
		}
	Now that begs the question why not pass the data reader directly to constructor? That would be better.
		private IDataReader dataReader;
		private Action<IDataReader, T> GetMapFunc()
		{
			var exps = new List<Expression>();
			var paramExp = Expression.Parameter(typeof(IDataRecord), "o7thDR");
			var targetExp = Expression.Parameter(typeof(T), "o7thTarget");
			var getPropInfo = typeof(IDataRecord).GetProperty("Item", new[] { typeof(string) });
			
			var columnNames = Enumerable.Range(0, dataReader.FieldCount)
										.Select(x => dataReader.GetName(x));
			foreach (var columnName in columnNames)
			{
				var property = typeof(T).GetProperty(columnName);
				if (property == null)
					continue;
				// use 'columnName' instead of 'property.Name' to speed up reader lookups
				//in case of certain readers.
                var columnNameExp = Expression.Constant(columnName);
                var getPropExp = Expression.MakeIndex(
                    paramExp, getPropInfo, new[] { columnNameExp });
				var castExp = Expression.TypeAs(getPropExp, property.PropertyType);
				var bindExp = Expression.Assign(
					Expression.Property(targetExp, property), castExp);
				exps.Add(bindExp);
			}
			return Expression.Lambda<Action<IDataReader, T>>(
				Expression.Block(exps), paramExp, targetExp).Compile();
		}
		internal Converter(IDataReader dataReader)
		{
			this.dataReader = dataReader;
			_convertAction = (Action<IDataReader, T>)_convertActionMap.GetOrAdd(
				typeof(T), (t) => GetMapFunc());
		}
		internal T CreateItemFromRow()
		{
			T result = new T();
			_convertAction(dataReader, result);
			return result;
		}
	Call it like 
		List<T> list = new List<T>();
		var converter = new Converter<T>(dr);
		while (dr.Read())
		{
			var obj = converter.CreateItemFromRow();
			list.Add(obj);
		}

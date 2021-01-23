		var paramExp = Expression.Parameter(typeof(IDataRecord), "o7thDR");
		var loopIncrementVariableExp = Expression.Parameter(typeof(int), "i");
		var columnNamesExp = Expression.Parameter(typeof(List<string>), "columnNames");
		var columnCountExp = Expression.Property(paramExp, "FieldCount");
		var getColumnNameExp = Expression.Call(paramExp, "GetName", Type.EmptyTypes, 
			Expression.PostIncrementAssign(loopIncrementVariableExp));
		var addToListExp = Expression.Call(columnNamesExp, "Add", Type.EmptyTypes, 
			getColumnNameExp);
		var labelExp = Expression.Label(columnNamesExp.Type);
		var getColumnNamesExp = Expression.Block(
			new[] { loopIncrementVariableExp, columnNamesExp },
			Expression.Assign(columnNamesExp, Expression.New(columnNamesExp.Type)),
			Expression.Loop(
				Expression.IfThenElse(
					Expression.LessThan(loopIncrementVariableExp, columnCountExp),
					addToListExp,
					Expression.Break(labelExp, columnNamesExp)),
				labelExp));
	would be the equivalent of 
		List<string> columnNames = new List<string>();
		for (int i = 0; i < reader.FieldCount; i++)
		{
			columnNames.Add(reader.GetName(i));
		}
	One may continue with the final expression, but there is a catch here making any further effort along this line futile. The above expression tree will be fetching the column names every time the final delegate is called which in your case is for every object creation, which is against the spirit of your requirement. 

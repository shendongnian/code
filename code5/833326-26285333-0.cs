		public override TEntity Find(params object[] keyValues)
		{
			if (keyValues.Length == 0)
				throw new ArgumentNullException("keyValues");
			return this.SingleOrDefault(GenerateKeyFilter(keyValues));
		}
		private Expression<Func<TEntity, bool>> GenerateKeyFilter(object[] keyValues)
		{
			var conditions = new List<BinaryExpression>();
			var objectParam = Expression.Parameter(typeof(TEntity));
			var keyFields = !!!Helper.KeyFields<TEntity>();
			if (keyFields.Count != keyValues.Length)
				throw new KeyNotFoundException();
			for (var c = 0; c < keyFields.Count; c++)
				conditions.Add(Expression.MakeBinary(
					ExpressionType.Equal,
					Expression.MakeMemberAccess(objectParam, keyFields[c]),
					Expression.Constant(keyValues[c], keyFields[c].PropertyType)
					));
			var result = conditions[0];
			for (var n = 1; n < conditions.Count; n++)
				result = Expression.And(result, conditions[n]);
			return Expression.Lambda<Func<TEntity, bool>>(result, objectParam);
		}

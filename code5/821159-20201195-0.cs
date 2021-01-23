	public static bool AreEqual<TDTO, TDATA>(TDTO dto, TDATA data) 
	{
		foreach(var prop in typeof(TDTO).GetProperties())
		{
			var dataProp = typeof(TDATA).GetProperty(prop.Name);
			if (dataProp == null)
				throw new InvalidOperationException(string.Format("Property {0} is missing in data class.", prop.Name));
			var compExpr = GetComparisonExpression(prop, dataProp);
			var del = compExpr.Compile();
			if (!(bool)del.DynamicInvoke(dto, data))
				return false;
		}
		return true;
	}
	
	private static LambdaExpression GetComparisonExpression(PropertyInfo dtoProp, PropertyInfo dataProp)
	{
		var dtoParam = Expression.Parameter(dtoProp.DeclaringType, "dto");
		var dataParam = Expression.Parameter(dataProp.DeclaringType, "data");
		return Expression.Lambda(
			Expression.MakeBinary(ExpressionType.Equal, 
				Expression.MakeMemberAccess(
					dtoParam, dtoProp), 
				Expression.MakeMemberAccess(
					dataParam, dataProp)), dtoParam, dataParam);
	}

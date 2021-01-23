			var properties = typeof (TModel).GetProperties();
			foreach (PropertyInfo info in properties)
			{
				ParameterExpression p1 = Expression.Parameter(typeof(TModel), "m");
				ParameterExpression p2 = Expression.Parameter(info.PropertyType, "m."+info.Name);
				Expression<Func<TModel, dynamic>> exResult = Expression.Lambda<Func<TModel, dynamic>>(p1, p2);
				
				helper.DisplayFor(exResult);
			}

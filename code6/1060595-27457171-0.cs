		public Func<T, Boolean> GetWhereExp<T>(List<WhereCondition> SearchFieldList, T item)
		{
			var pe = Expression.Parameter(item.GetType(), "c");
			Expression combined = null;
			if (SearchFieldList != null)
			{
				foreach (var fieldItem in SearchFieldList)
				{
					var columnNameProperty = Expression.Property(pe, fieldItem.ColumName);
					var columnValue = Expression.Constant(fieldItem.Value);
					var e1 = Expression.Equal(columnNameProperty, columnValue);
					combined = combined == null ? e1 : Expression.And(combined, e1);
				}
			}
			var result = Expression.Lambda<Func<T, bool>>(combined, pe);
			return result.Compile();
		}

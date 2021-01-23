	public static TEntity ExtractEntity<TEntity>(Dictionary<string, string> row)  where TEntity : class
	{
		var entity = Activator.CreateInstance<TEntity>();
		var entityType = typeof(TEntity);
		foreach (var info in entityType.GetProperties())
		{
			try
			{
				var converter = TypeDescriptor.GetConverter(info.PropertyType);
				if (!converter.CanConvertTo(info.PropertyType)) continue;
			
				info.SetValue(entity, converter.ConvertTo(row[info.Name], info.PropertyType));
			}
			catch {}
		}
		return entity;
	}

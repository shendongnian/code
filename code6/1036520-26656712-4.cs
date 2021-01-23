	entity.GetType().GetProperties()
		.Where(p => typeof(IEnumerable<TDomainEntity>).IsAssignableFrom(p.PropertyType))
		.ToList()
		.ForEach(p => 
		{
			var value = (IEnumerable<TDomainEntity>)p.GetValue(entity);
			if(value == null) return;
			value.ToList().ForEach(i => SetInsertMetadata((TDomainEntity)i));
		});

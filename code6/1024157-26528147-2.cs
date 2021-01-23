	var propertyName = expression.Member.Name;												
    var propertyType = __get_property_type__(propertyName);
    if(propertyType==Property || propertyType==Complex)
    {
		_context.Entry<T>(entity)
			.Property(propertyName).IsModified = true;
        continue;
	}
    if(propertyType==Navigational){
	
		// hm, do we need Attach it first?!
		// not sure.. have to test first.
		dynamic underlyingReference = entity.GetType()
		 		.GetProperty(propertyName)
				.GetValue(entity, null);
		
		_context.Entry(underlyingReference).State = EntityState.Modified;
	}

	private static void UpdateIfDifferent<TOriginal, TOriginalProperty, TUpdated, TUpdatedProperty>
  		(TOriginal original, Expression<Func<TOriginal, TOriginalProperty>> originalProperty, 
			TUpdated updated, Expression<Func<TUpdated, TUpdatedProperty>> updatedProperty)
  	{
		var updatedMember = (updatedProperty.Body as MemberExpression).Member as PropertyInfo;
		var updatedValue = updatedMember.GetValue(updated);
		var originalMember = (originalProperty.Body as MemberExpression).Member as PropertyInfo;
		var originalValue = originalMember.GetValue(original);
		
		if (!object.Equals(updatedValue, originalValue))
			originalMember.SetValue(original, updatedValue);
    }

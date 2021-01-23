        protected void SetError<T>(Expression<Func<T>> prop, String error)
		{
			String propertyName = PropertySupport.ExtractPropertyName(prop);
		
			if (error == null)
				errors.Remove(propertyName);
			else
				errors[propertyName] = error;
		
			OnHasErrorsChanged();
		}
		protected string GetError<T>(Expression<Func<T>> prop, String error)
		{
			String propertyName = PropertySupport.ExtractPropertyName(prop);
			String s;
			errors.TryGetValue(propertyName, out s);
			return s;
		}

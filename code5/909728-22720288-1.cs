    public void SetPropertyValue<O, T>(O obj, Expression<Func<O, T>> property, T value)
    {
    	var memberSelectorExpression = property.Body as MemberExpression;
    	if (memberSelectorExpression != null)
    	{
    		var p = memberSelectorExpression.Member as PropertyInfo;
    		if (p != null)
    		{
    			p.SetValue(obj, value, null);
    		}
    	}
    }

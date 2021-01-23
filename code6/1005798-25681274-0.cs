    private void Validate(Expression<Func<DisplayContentViewModel, object>> propertyLambda)
    {
        var key = this.GetValidationKey(propertyLambda);
    
        this.validationsDictionary[key]();
    }
    
    private void CreateValidationRule(
        Expression<Func<DisplayContentViewModel, object>> propertyLambda,
        Action validationAction)
    {
        var key = this.GetValidationKey(propertyLambda);
    
        if (this.validationsDictionary.ContainsKey(key))
        {
            return;
        }
    
        this.validationsDictionary.Add(key, validationAction);
    }
    
    private string GetValidationKey(Expression<Func<DisplayContentViewModel, object>> propertyLambda)
    {
        var member = propertyLambda.Body as MemberExpression;
    
        if (member == null)
        {
            throw new ArgumentException(
                string.Format("Expression '{0}' refers to a method, not a property.", propertyLambda));
        }
    
        var propInfo = member.Member as PropertyInfo;
    
        if (propInfo == null)
        {
            throw new ArgumentException(
                string.Format("Expression '{0}' refers to a field, not a property.", propertyLambda));
        }
    
        return propInfo.Name;
    }

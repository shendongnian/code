    private void Validate(Expression<Func<DisplayContentViewModel, object>> propertyLambda)
    {
        var key = this.GetValidationKey(propertyLambda);
    
        this.validationsDictionary[key]();
    }
    
    private void CreateValidationRule(
        Expression<Func<DisplayContentViewModel, object>> propertyLambda,
        Action validationAction)
    {
        if (this.validationsDictionary == null)
        {
            this.validationsDictionary = new Dictionary<string, Action>();
        }
    
        var key = this.GetValidationKey(propertyLambda);
    
        if (this.validationsDictionary.ContainsKey(key))
        {
            return;
        }
    
        this.validationsDictionary.Add(key, validationAction);
    }
    
    private string GetValidationKey(Expression<Func<DisplayContentViewModel, object>> propertyLambda)
    {
        var member = propertyLambda.Body as UnaryExpression;
    
        if (member == null)
        {
            throw new ArgumentException(
                string.Format("Expression '{0}' can't be cast to a UnaryExpression.", propertyLambda));
        }
    
        var operand = member.Operand as MemberExpression;
    
        if (operand == null)
        {
            throw new ArgumentException(
                string.Format("Expression '{0}' can't be cast to an Operand.", propertyLambda));
        }
    
        return operand.Member.Name;
    }

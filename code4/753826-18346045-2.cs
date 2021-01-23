    var addMethod = typeof(Dictionary<string, object>).GetMethod("Add");
    var expression = Expression.Lambda<Func<Dictionary<string, object>>>(
    	Expression.ListInit(
    		Expression.New(typeof(Dictionary<string, object>)),
    		Expression.ElementInit(
    			addMethod,
    			Expression.Constant("Prop1"),
    			value1Expression),
    		Expression.ElementInit(
    			addMethod,
    			Expression.Constant("Prop2"),
    			value2Expression)),
        itemParameterExpression);

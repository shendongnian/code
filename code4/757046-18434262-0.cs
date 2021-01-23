    public IQueryable<TModel> Search<TModel>(IQueryable<TModel> model, string selector, string searchFor)
    {
    	var param = Expression.Parameter(typeof(TModel), "x");
        	var contains = Expression.Call(
        		Expression.PropertyOrField(param, selector),
        		"Contains", null, Expression.Constant(searchFor)
        	);
        	var predicate = Expression.Lambda<Func<TModel, bool>>(contains, param);
        
        	model = model.Where(predicate);
    	return model;
    }

    public IQueryable<TModel> Search<TModel>(IQueryable<TModel> model, string selector, object searchFor)
    {
    	var param = Expression.Parameter(typeof(TModel), "x");
    	var tostring = Expression.Call(
    		Expression.PropertyOrField(param, selector),
    		"ToString", null, null
    		);
    	var tolower = Expression.Call(
    		tostring,
    		"ToLower", null, null
    		);
    	var contains = Expression.Call(
    		tolower,
    		"Contains", null, Expression.Constant(searchFor)
                    );
    	var predicate = Expression.Lambda<Func<TModel, bool>>(contains, param);
    
    	model = model.Where(predicate);
    
            return model;
    }

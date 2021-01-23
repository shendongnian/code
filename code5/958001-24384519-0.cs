    [EdmFunction("TestingDbEntities", "FilterCustomersByRating")]
    public virtual IQueryable<FilterCustomersByRating_Result> FilterCustomersByRating(Nullable<int> rating)
    {
    	var ratingParameter = rating.HasValue ?
    		new ObjectParameter("Rating", rating) :
    		new ObjectParameter("Rating", typeof(int));
    
    	return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FilterCustomersByRating_Result>("[TestingDbEntities].[FilterCustomersByRating](@Rating)", ratingParameter);
    }

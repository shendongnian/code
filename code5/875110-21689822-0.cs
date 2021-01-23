    public IHttpActionResult Get(ODataQueryOptions<YourEntity> odataQueryOptions)
    {
        //Your applyTo logic and results.
        
        if (odataQueryOptions.SelectExpand != null)
        {
            Request.SetSelectExpandClause(odataQueryOptions.SelectExpand.SelectExpandClause);
        }
 
        return Ok(results, results.GetType());
    }
 
    private IHttpActionResult Ok(object content, Type type)
    {
        Type resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);
        return Activator.CreateInstance(resultType, content, this) as IHttpActionResult;
    }

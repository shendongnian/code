    public class GenericRouteHandler<T> : IRouteHandler where T : IHttpHandler, new()
    {
	public IHttpHandler GetHttpHandler(RequestContext requestContext)
	{
		return new T();
	}
    }

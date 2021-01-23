    public static T Get<T>(this IOwinContext context)
    {
  	  if (context == null)
  	  {
		throw new ArgumentNullException("context");
	  }
	  return context.Get<T>(OwinContextExtensions.GetKey(typeof(T)));    
    }
    public static T Set<T>(this IOwinContext context, T value)
    {
	  if (context == null)
	  {
		throw new ArgumentNullException("context");
	  }
 	  return context.Set<T>(OwinContextExtensions.GetKey(typeof(T)), value);
    }

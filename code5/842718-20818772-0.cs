    using MvcSiteMapProvider.Globalization;
    
    public class MyStringLocalizer
    	: StringLocalizer
    {
    	public MyStringLocalizer(IMvcContextFactory mvcContextFactory) 
    		: base(mvcContextFactory)
    	{
    	}
    
    	protected override string GetExplicitResourceString(string attributeName, string defaultValue, bool throwIfNotFound, NameValueCollection explicitResourceKeys)
    	{
    		if (attributeName == null)
    		{
    			throw new ArgumentNullException("attributeName");
    		}
    		string globalResourceObject = null;
    		if (explicitResourceKeys != null)
    		{
    			string[] values = explicitResourceKeys.GetValues(attributeName);
    			if ((values == null) || (values.Length <= 1))
    			{
    				return globalResourceObject;
    			}
    			
    			// Take this piece out
    			
    			//var httpContext = mvcContextFactory.CreateHttpContext();
    			//try
    			//{
    			//	globalResourceObject = httpContext.GetGlobalResourceObject(values[0], values[1]) as string;
    			//}
    			//catch (System.Resources.MissingManifestResourceException)
    			//{
    			//	if (defaultValue != null)
    			//	{
    			//		return defaultValue;
    			//	}
    			//}
    			
    			// TODO: Provide your alternative string resource lookup here, and return the defaultValue in
    			// the case where the key doesn't exist in the resource.
    			
    			if ((globalResourceObject == null) && throwIfNotFound)
    			{
    				throw new InvalidOperationException(String.Format(Resources.Messages.ResourceNotFoundWithClassAndKey, values[0], values[1]));
    			}
    		}
    		return globalResourceObject;
    	}
    }

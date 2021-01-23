    public static bool RemoveQueryString(ref System.Web.HttpRequest httpReq, string key)
    {
    	PropertyInfo requestQueryString = null;
    	bool bCanProceed = true;
    	try	{
    		try {
    			requestQueryString = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
    		} catch (System.Reflection.AmbiguousMatchException) {
    			bCanProceed = false;
    		} catch (System.ArgumentNullException) {
    			bCanProceed = false;
    		}
    		if (bCanProceed) {
    			try {
    				if (requestQueryString != null) {
    					// make collection editable
    					requestQueryString.SetValue(httpReq.QueryString, false, null);
    				} else bCanProceed = false;
    				
    			} catch (System.Reflection.TargetException) {
    				bCanProceed = false;
    			} catch (System.Reflection.TargetParameterCountException) {
    				bCanProceed = false;
    			} catch (System.Reflection.TargetInvocationException) {
    				bCanProceed = false;
    			} catch (System.MethodAccessException) {
    				bCanProceed = false;
    			} catch (System.ArgumentException) {
    				bCanProceed = false;
    			}
    			if (bCanProceed) {
    				try {
    					// remove
    					httpReq.QueryString.Remove(key);
    				} catch (System.NotSupportedException) {
    					bCanProceed = false;
    				}
    			}
    		}
    	} catch (System.Exception) {
    		bCanProceed = false;
    	}
    	return bCanProceed;
    }

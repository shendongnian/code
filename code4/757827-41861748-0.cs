    	public class WebServiceAuthenticationAttribute : AuthorizationFilterAttribute
    	{
    		public override void OnAuthorization(HttpActionContext actionContext)
    		{
    			var authenticationHeaderValue = actionContext.Request.Headers.Authorization;
    
    			try
    			{
    				if (authenticationHeaderValue != null)
    				{
    					var webRequestInfo = new WebRequestInfo(actionContext.Request.Method, actionContext.Request.RequestUri);
    					this.AuthenticationHeaderService.LogOnUsingAuthenticationHeader(authenticationHeaderValue, webRequestInfo);
    				}
    				else if (actionContext.Request.Content.IsFormData())
    				{
    					Task<NameValueCollection> formVals = actionContext.Request.Content.ReadAsFormDataAsync();
    					this.AuthenticationFormService.LogOnUsingFormsAuthentication(formVals.Result);
    
    					// reset the underlying stream to the beginning so that others may use it in the future...
    					using (var s = new System.IO.MemoryStream())
    					{
    						var ctx = (HttpContextBase) actionContext.Request.Properties["MS_HttpContext"];
    						ctx.Request.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
    					}
    				}
    			}
    			catch (Exception)
    			{
    				throw;
    			}
            }
        }

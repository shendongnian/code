    namespace YourNameSpaceHere
    {
    	public class LanguageModule : IHttpModule
    	{
    
    		public void Init(System.Web.HttpApplication context)
    		{
    			context.AcquireRequestState += OnAcquireRequestState;
    		}
    
    		public void OnAcquireRequestState(object sender, EventArgs eventArgs)
    		{
    			HttpApplication httpApplication = sender as HttpApplication;
    
    			string lang = null;
    			if (httpApplication.Request.Cookies["<CookieNameHere>"] == null)
    			{
    				lang = Thread.CurrentThread.CurrentCulture.Name;
    				httpApplication.Response.Cookies["<CookieNameHere>"].Value = lang;
    			}
    			else
    			{
    				lang = httpApplication.Request.Cookies["<CookieNameHere>"].Value;
    			}
    
    			if (lang != Thread.CurrentThread.CurrentCulture.Name)
    			{
    				if (Language.IsValidCultureInfoName(lang))
    				{
    					var culture = new System.Globalization.CultureInfo(lang);
    
    					Thread.CurrentThread.CurrentCulture = culture;
    					Thread.CurrentThread.CurrentUICulture = culture;
    
    					httpApplication.Response.Cookies["<CookieNameHere>"].Value = lang;
    				}
    			}
    		}
    
    		public void Dispose()
    		{
    		}
    
    	}
    }

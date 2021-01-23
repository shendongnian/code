    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class ProspectProfileAuthorizationAttribute : AuthorizeAttribute
    {
       /// <summary>
       /// Special authorization check based on whether request contain valid data or not.
       /// </summary>
       /// <param name="filterContext"></param>
       public override void OnAuthorization(AuthorizationContext filterContext)
       {
           Guard.ArgumentNotNull(filterContext, "filterContext");
           Guard.ArgumentNotNull(filterContext.Controller, "filterContext.Controller");
    
           bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(
               typeof(CustomAllowAnonymous), inherit: true)
                                    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                                        typeof(CustomAllowAnonymous), inherit: true);
    
           if (skipAuthorization)
           {
               return;
           }
    
           var request = filterContext.RequestContext.HttpContext.Request;
    
           NameValueCollection parameterCollection = ReadQueryStringData(filterContext, request);
    
           if (parameterCollection.Count < 3)
           {
               throw new InvalidOperationException("Request with invalid number of parameter");
           }
    
           // Check 1: Is request authenticated i.e. coming from browser by a logged in user
           // No further check required.
           if (request.IsAuthenticated)
           {
               return;
           }
    
           // Check 2: Request is coming from an external source, is it valid i.e. does it contains
           // valid download code.
           if (string.IsNullOrEmpty(downloadCode))
           {
               throw new InvalidOperationException(Constants.Invalid_Download_Code);
           }
    
           if (!userType.Equals(Constants.SystemIntegrationUserName))
           {
               var exportReportService = DependencyResolver.Current.GetService<IExportReportService>();
    
               if (exportReportService != null)
               {
                   if (!exportReportService.VerifyDownloadCode(downloadCode))
                   {
                       // Invalid partner key
                       throw new InvalidOperationException(Constants.Invalid_Download_Code);
                   }
               }
           }
       }
    
       private static NameValueCollection ReadQueryStringData(AuthorizationContext filterContext, HttpRequestBase request)
       {
           // Obtain query string parameter from request
           //original
           //var encryptedData = request.Params["data"];
    
           // Applying the replace for space with + symb
           var encryptedData = request.Params["data"].Replace(" ","+");
    
           var decryptedData = EncryptionHelper.DecryptString(encryptedData);
    
           // Validate the parameter
           var dict = HttpUtility.ParseQueryString(decryptedData);
    
           return dict;
          
       }
    }

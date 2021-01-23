    public static class SBA
    {
    
        public static void Redirect(string Url)
        {
            try
            {
                //redirect only when 'IsRequestBeingRedirected' is false
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                    Uri uri = null;
                    bool isUriValid = Uri.TryCreate(Url, UriKind.RelativeOrAbsolute, out uri);
    
                    if (!isUriValid)
                    {
                        throw new SecurityException("Invalid uri " + Url);
                    }
    
                    //Below check is not required but checked
                    //to make obsolate security check 
                    if (uri.OriginalString == null)
                    {
                        throw new SecurityException("Invalid uri " + Url);
                    }
    
                    // check if host is from configured trusted host list
                    if (uri.IsAbsoluteUri)
                    {
                        var tempAppSetting = ConfigBLL.GetAppSetting(AppSettingSectionType.OtherSetting).Other;
                        if (!tempAppSetting.RedirectTrustedUrls.Contains(uri.Host))
                        {
                            throw new SecurityException("Untrusted url redirection detected. Can not redirect.");
                        }
                    }
    
                    var tempUrl = uri.OriginalString;
    
                    //Few more logical check 
    
                    HttpContext.Current.Response.Redirect(tempUrl, true);
                }
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(System.Threading.ThreadAbortException))
                {
                    throw;
                }
            }
        }
    }

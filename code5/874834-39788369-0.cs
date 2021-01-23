    private PrincipalCustom SetPrincipalIPAndBrowser()
    {
         return new PrincipalCustom
         {
           IP = RequestHelper.GetIPFromCurrentRequest(HttpContext.Current.Request),
           Browser = RequestHelper.GetBrowserFromCurrentRequest(HttpContext.Current.Request),
        
        /* User is not authenticated, but Identity must be set anyway. If not, error occurs */
           Identity = new IdentityCustom { IsAuthenticated = false }
         };
    }
    
       
      
   
    

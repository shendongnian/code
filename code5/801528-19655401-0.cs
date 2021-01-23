      class XssModule : IHttpModule
        {
            
            #region IHttpModule Members
            public void Init(HttpApplication application)
            {
              application.PostAcquireRequestState += new EventHandler(Application_PostAcquireRequestState);
            }
    
            public void Dispose()
            {
            }
    
            #endregion
    
            private void Application_PostAcquireRequestState(object sender, EventArgs e)
            {
                
                if (HttpContext.Current.Session != null)
                {
                 //Perform the iteration on the form elements here.                 
                }
            }
        }
